using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using schoolapp.Models;

namespace schoolapp.Infrastructure.Services
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>?> GetCart();
        Task<Cart?> GetCart(int id);
        Task<Cart?> PutCart(int id, Cart cart);
        Task<bool?> PostCart(Cart cart);
        Task<bool> DeleteCart(int id);
    }
}