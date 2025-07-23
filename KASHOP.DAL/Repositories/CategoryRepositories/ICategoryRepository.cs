using KASHOP.DAL.Models.Category;

namespace KASHOP.DAL.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<int> AddAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync(bool AsNoTracking = false);
        Task<Category>? GetByIdAsync(int id);
        Task<int> UpdateAsync(Category category);
        Task<int> RemoveAsync(Category category);
    }
}