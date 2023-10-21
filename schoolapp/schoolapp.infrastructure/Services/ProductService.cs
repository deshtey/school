using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Infrastructure.Persistence;
using schoolapp.Models;

namespace schoolapp.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;
    public ProductService(ApplicationDbContext context, CancellationToken cancellationToken)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetProducts()
    {
        if (_context.Products == null)
        {
            return new List<Product>();
        }
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return null;
        }
        return product;
    }

    public async Task<bool> PutProduct(int id, Product product)
    {
        product.LastModified = DateTime.Now;

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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
    public async Task<Product> AddProduct(ProductDto productDto)
    {
        string imageName = null;
        if (productDto.ImageFile != null && productDto.ImageFile.Length > 0)
        {
            IFormFile formFile = productDto.ImageFile;
            var rootPath = _env.ContentRootPath;
            var filePath = $"{rootPath}\\Images\\Category\\";
            imageName = formFile.Name;
        }

        try
        {
            var product = new Product
            {
                LastModified = DateTime.Now,
                AvailableInPOS = true,
                CategoryId = productDto.CategoryId,
                Code = productDto.Code,
                UnitCost = productDto.UnitCost,
                UnitPrice = productDto.UnitPrice,
                LastModifiedBy = productDto.ModifiedBy,
                ReorderLevel = productDto.ReorderLevel,
                Quantity = productDto.Quantity,
                ProductName = productDto.Name,
                Image = imageName == null ? null : imageName
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
        catch (Exception ex)
        {
            var er = ex.Message;
            throw;
        }

    }

    public async Task DeleteProduct(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid product ID.");
        }

        var product = await _context.Products.FindAsync(id) ?? throw new InvalidOperationException("Product not found.");
        try
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Handle specific exceptions or log the error
            throw new Exception("Error deleting the product.", ex); // Custom exception type
        }
    }
    private bool ProductExists(int id)
    {
        return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
