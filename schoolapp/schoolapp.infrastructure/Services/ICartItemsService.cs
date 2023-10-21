using schoolapp.Domain.Entities;

namespace schoolapp.Infrastructure.Services
{
    public interface ICartItemsService
    {
        bool CartItemExists(int id);
        Task<bool> DeleteCartItem(int id);
        Task<IEnumerable<CartItem>> GetCartItem();
        Task<CartItem> GetCartItem(int id);
        Task<CartItem> PostCartItem(CartItem CartItem);
        Task<bool> PutCartItem(int id, CartItem CartItem);
    }
}
