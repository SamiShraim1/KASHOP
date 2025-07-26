using KASHOP.DAL.Data;
using KASHOP.DAL.Models.Brand;
using KASHOP.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories.BrandRepositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {


        public BrandRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
