using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.Entities.Specifications;
using TopNewsApi.Core.Entities.Tokens;
using TopNewsApi.Core.Entities.User;
using TopNewsApi.Core.Interfaces;

namespace TopNewsApi.Core.Services
{ 
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<RefreshToken> _tokenRepo;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IConfiguration configuration, IRepository<RefreshToken> tokenRepo, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _tokenRepo = tokenRepo;
            _userManager = userManager;
        }

        public async Task Create(RefreshToken token)
        {
            await _tokenRepo.Insert(token);
            await _tokenRepo.Save();
        }

        public async Task Delete(RefreshToken token)
        {
            await _tokenRepo.Delete(token);
            await _tokenRepo.Save();
        }

        public async Task<RefreshToken?> Get(string token)
        {
            var result = await _tokenRepo.GetListBySpec(new RefreshTokenSpecification.GetRefreshToken(token));
            return (RefreshToken)result.FirstOrDefault();
        }

        public async Task<IEnumerable<RefreshToken>> GetAll()
        {
            IEnumerable<RefreshToken> result = await _tokenRepo.GetAll();
            return result;
        }

        public async Task Update(RefreshToken token)
        {
            await _tokenRepo.Update(token);
            await _tokenRepo.Save();
        }


        public async Task<Tokens> GenerateJwtTokensAsync(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
               {
                    new Claim("Id", user.Id),
                    new Claim("Name", user.FirstName),
                    new Claim("Surname", user.LastName),
                    new Claim("Email", user.Email),
                    new Claim("EmailConfirm", user.EmailConfirmed.ToString()),
                    new Claim("PhoneNumber", user.PhoneNumber ?? ""),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roles[0]),
                    new Claim(JwtRegisteredClaimNames.Aud, _configuration["JwtConfig:Audience"]),
                    new Claim(JwtRegisteredClaimNames.Iss, _configuration["JwtConfig:Issuer"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };


            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);


            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsUsed = false,
                UserId = user.Id,
                AddedDate = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddDays(1),
                IsRevoked = false,
                Token = RandomString(25) + Guid.NewGuid()
            };

            await Create(refreshToken);

            var tokens = new Tokens();
            tokens.Token = jwtToken;
            tokens.refreshToken = refreshToken;

            return tokens;


        }


        private string RandomString(int langth)
        {
            var random = new Random();
            var chars = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            return new string(Enumerable.Repeat(chars, langth).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class Tokens
    {
        public string Token { get; set; } = String.Empty;
        public RefreshToken refreshToken { get; set; }
    }
}
