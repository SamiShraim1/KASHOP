using KASHOP.DAL.DTOs.CategoryDTOs.Requests;
using KASHOP.DAL.DTOs.CategoryDTOs.Responses;
using KASHOP.DAL.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();
        Task<CategoryResponseDTO>? GetByIdAsync(int id);
        Task<int> AddAsync(CategoryRequestDTO dto);
        Task<int> UpdateAsync(int id, CategoryRequestDTO dto);
        Task<int> RemoveAsync(int id);
        Task<bool> ToggleStatusAsync(int id);
    }
}
