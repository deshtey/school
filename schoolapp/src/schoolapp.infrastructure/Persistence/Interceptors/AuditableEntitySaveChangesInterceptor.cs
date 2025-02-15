using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using schoolapp.application.Common.Interfaces;
using schoolapp.Domain.Common;
using schoolapp.Infrastructure.Security.CurrentUserProvider;

namespace schoolapp.Infrastructure.Persistence.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IUserProvider _userProvider;
    private readonly IDateTimeService dateTimeService;

    public AuditableEntitySaveChangesInterceptor(
         IUserProvider userProvider, IDateTimeService dateTimeService)
    {
        _userProvider = userProvider;
        this.dateTimeService = dateTimeService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        var userRes = _userProvider.GetCurrentUser();
        if (!userRes.IsSuccess)
        {
            return;
        }
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedByUserId = userRes.Value.Id;
                entry.Entity.Created = DateTimeOffset.Now;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModifiedByUserId = userRes.Value.Id;
                entry.Entity.LastModified = DateTimeOffset.Now;
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}
