using KASHOP.DAL.DTOs.CategoryDTOs.Requests;
using KASHOP.DAL.DTOs.CategoryDTOs.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Models.Category;
using KASHOP.DAL.Repositories.CategoryRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
        {
            var categories = await repository.GetAllAsync();
            return categories.Adapt<IEnumerable<CategoryResponseDTO>>();
        }

        public async Task<CategoryResponseDTO>? GetByIdAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            return category == null ? null : category.Adapt<CategoryResponseDTO>();
        }

        public async Task<int> AddAsync(CategoryRequestDTO dto)
        {
            var category = dto.Adapt<Category>();
            return await repository.AddAsync(category);
        }

        public async Task<int> UpdateAsync(int id, CategoryRequestDTO dto)
        {
            var category = await repository.GetByIdAsync(id);
            if (category == null)
                return 0;

            dto.Adapt(category);
            return await repository.UpdateAsync(category);
        }

        public async Task<int> RemoveAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            return category == null ? 0 : await repository.RemoveAsync(category);
        }
        public async Task<bool> ToggleStatusAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            if (category == null)
                return false;

            category.Status = category.Status = category.Status == Status.Active ? Status.In_active : Status.Active;
            await repository.UpdateAsync(category);
            return true;
        }
    }
}
