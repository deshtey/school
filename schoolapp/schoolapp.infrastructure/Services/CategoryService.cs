using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Common.Models;
using schoolapp.Infrastructure.Persistence;
using schoolapp.Models;

namespace schoolapp.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ApplicationDbContext context, IWebHostEnvironment env, ILogger<CategoryService> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            if (_context.Categories == null)
            {
                return new List<Category>();
            }
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            if (_context.Categories == null)
            {
                return new Category();
            }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return new Category();
            }

            return category;
        }
        public async Task<bool> PutCategory(int id, Category category)
        {

            category.LastModified = DateTime.UtcNow;
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<Category> PostCategory(CategoryDto categoryVm)
        {
            if (_context.Categories == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Categories'  is null.");
            }

            var category = new Category();
            try
            {
                if (categoryVm.ImageFile.Length > 0)
                {
                    IFormFile formFile = categoryVm.ImageFile;
                }
                var rootPath = _env.ContentRootPath;
                var filePath = $"{rootPath}\\Images\\Category\\";
                category.Image = categoryVm.ImageFile.Name;
                category.CategoryName = categoryVm.Name;
                category.DisplayOrder = categoryVm.DisplayOrder;
                category.Image = categoryVm.ImageFile.FileName;
                category.LastModified = DateTime.Now;
                category.LastModifiedBy = categoryVm.ModifiedBy;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteCategory(int id)
        {
            if (_context.Categories == null)
            {
                return false;
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
