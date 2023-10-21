using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using schoolapp.Models;
using FluentValidation;
using schoolapp.Infrastructure.Services;
using schoolapp.Infrastructure.Persistence;

namespace schoolapp.Services
{
    public class CartItemsService  : ICartItemsService
    {
        private readonly ApplicationDbContext _context;
        public CartItemsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartItem>> GetCartItem()
        {
            return _context.CartItems == null ? (IEnumerable<CartItem>?)null : await _context.CartItems.ToListAsync();
        }


        public async Task<CartItem> GetCartItem(int id)
        {
            if (_context.CartItems == null)
            {
                return null;
            }
            var CartItems = await _context.CartItems.FindAsync(id);

            if (CartItems == null)
            {
                return null;
            }

            return CartItems;
        }

        public async Task<bool> PutCartItem(int id, CartItem CartItem)
        {
            _context.Entry(CartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return false;
        }

        //public async Task<CartItem> PostCartItem(CartItem cartItem, CancellationToken cancellationToken)
        //{
        //    if (_context.CartItems == null)
        //    {
        //        return null;
        //    }
        //    var validator = new TodoListValidator(_context);
        //    var validationResult = await validator.ValidateAsync(cartItem, cancellationToken);

        //    // Check if validation failed
        //    if (!validationResult.IsValid)
        //    {
        //        // Handle validation errors
        //        return Result<TodoList>.Failure(validationResult.Errors.Select(e => e.ErrorMessage));
        //    }
        //    _context.CartItems.Add(cartItem);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Result<TodoList>.Success(cartItem);
        //}

        public async Task<bool> DeleteCartItem(int id)
        {
            if (_context.CartItems == null)
            {
                return false;
            }
            var CartItems = await _context.CartItems.FindAsync(id);
            if (CartItems == null)
            {
                return false;
            }

            _context.CartItems.Remove(CartItems);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool CartItemExists(int id)
        {
            return (_context.CartItems?.Any(e => e.CartItemId == id)).GetValueOrDefault();
        }

        public Task<CartItem> PostCartItem(CartItem CartItem)
        {
            throw new NotImplementedException();
        }
    }
}
