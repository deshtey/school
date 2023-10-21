using schoolapp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using schoolapp.Models;

namespace schoolapp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<CartItem> CartItems { get; }
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
