using KASHOP.BLL.Services.GenericService;
using KASHOP.DAL.DTOs.BrandDTOs.Requests;
using KASHOP.DAL.DTOs.BrandDTOs.Responses;
using KASHOP.DAL.Models.Brand;
using KASHOP.DAL.Repositories.BrandRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.BrandServices
{
    public class BrandService : GenericService<BrandRequestDTO, BrandResponseDTO, Brand> , IBrandService
    {
        public BrandService(IBrandRepository repository) : base(repository) { }

    }
}
