using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Ip;
using TopNewsApi.Core.Entities;

namespace TopNewsApi.Core.Services
{
    public interface IDashdoardAccessService
    {
        Task<List<DashboardAccessDTO>> GetAll();
        Task Create(DashboardAccessDTO model);
        Task Delete(int id);
        Task<DashboardAccessDTO?> Get(string IpAddress);
        Task<DashboardAccessDTO?> Get(int id);
        Task Update(DashboardAccessDTO model);
    }
}
