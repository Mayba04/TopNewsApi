using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Category;
using TopNewsApi.Core.DTOs.Roles;

namespace TopNewsApi.Core.Interfaces
{
    public interface IRolesService
    {
        Task<List<RolesDTO>> GetAll();
    }
}
