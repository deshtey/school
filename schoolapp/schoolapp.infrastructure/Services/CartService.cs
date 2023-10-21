using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using schoolapp.Infrastructure.Persistence;
using schoolapp.Infrastructure.Services;

namespace schoolapp.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cart>?> GetCart()
        {
            if (_context.Carts == null)
            {
                return null;
            }
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart?> GetCart(int id)
        {
            if (_context.Carts == null)
            {
                return null;
            }
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return null;
            }
            return cart;
        }
  
        public async Task<Cart?> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return null;
            }
            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
        }

        public async Task<bool?> PostCart(Cart cart)
        {
            if (_context.Carts == null)
            {
                return null;
            }
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCart(int id)
        {
            if (_context.Carts == null)
            {
                return true;
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return true;
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return true;
        }
        private bool CartExists(int id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
