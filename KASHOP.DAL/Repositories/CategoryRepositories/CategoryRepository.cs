﻿using KASHOP.DAL.Data;
using KASHOP.DAL.Models.Category;
using KASHOP.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories.CategoryRepositories
{
    public class CategorRepository : GenericRepository<Category>, ICategoryRepository
    {


        public CategorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
