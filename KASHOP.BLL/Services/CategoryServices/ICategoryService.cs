using Azure;
using Azure.Core;
using KASHOP.BLL.Services.GenericService;
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
    public interface ICategoryService : IGenericService<CategoryRequestDTO, CategoryResponseDTO, Category>
    {

    }
}
