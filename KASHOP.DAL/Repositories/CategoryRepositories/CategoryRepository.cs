using KASHOP.DAL.Data;
using KASHOP.DAL.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbcontext;

        public CategoryRepository(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        public async Task<int> AddAsync(Category category)
        {
            await dbcontext.categories.AddAsync(category);
            return await dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(bool AsNoTracking = false)
        {
            if (AsNoTracking) 
            return await dbcontext.categories.ToListAsync();

            return await dbcontext.categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category>? GetByIdAsync(int id) =>  await dbcontext.categories.FirstOrDefaultAsync(c => c.Id == id);
        

        public async Task<int> RemoveAsync(Category category)
        {
            dbcontext.categories.Remove(category);
            return await dbcontext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Category category)
        {
            dbcontext.categories.Update(category);
            return await dbcontext.SaveChangesAsync();
        }
    }
}
