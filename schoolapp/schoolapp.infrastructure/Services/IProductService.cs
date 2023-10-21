using schoolapp.Application.Common.Models;
using schoolapp.Models;

namespace schoolapp.Infrastructure.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task<bool> PutProduct(int id, Product product);
    Task<Product> AddProduct(ProductDto productDto);
    Task DeleteProduct(int id);
}