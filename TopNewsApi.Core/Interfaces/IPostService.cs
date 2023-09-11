﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Category;
using TopNewsApi.Core.DTOs.Post;

namespace TopNewsApi.Core.Interfaces
{
    public interface IPostService
    {
        Task<List<PostDTO>> GetAll();
        Task<List<PostDTO>> GetByCategory(int id);
        Task<PostDTO?> Get(int id);
        Task Create(PostDTO model);
        Task Update(PostDTO model);
        Task Delete(int id);
        Task<PostDTO> GetById(int id);
        Task<List<PostDTO>> Search(string searchString);
    }
}
