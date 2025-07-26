using KASHOP.BLL.Services.GenericService;
using KASHOP.DAL.DTOs.CategoryDTOs.Requests;
using KASHOP.DAL.DTOs.CategoryDTOs.Responses;
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
    public class CategoryService : GenericService<CategoryRequestDTO, CategoryResponseDTO, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository):base(repository) { }
    


    }
}
