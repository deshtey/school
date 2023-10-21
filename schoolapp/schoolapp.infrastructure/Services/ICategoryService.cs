using schoolapp.Application.Common.Models;
using schoolapp.Models;

namespace schoolapp.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> PostCategory(CategoryDto categoryVm);
        Task<bool> PutCategory(int id, Category category);
    }
}
