using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Category;
using TopNewsApi.Core.Services;

namespace TopNewsApi.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAll();
       
        Task<CategoryDTO?> Get(int id);
        Task<ServiceResponse> GetByName(CategoryDTO model);
        Task<CategoryDTO> GetByName(string NameCategory);
        Task Create(CategoryDTO model);
        Task Update(CategoryDTO model);
        Task Delete(int id);

    }
}
