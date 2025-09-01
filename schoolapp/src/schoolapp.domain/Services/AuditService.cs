using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using schoolapp.Domain.Common;

namespace schoolapp.Domain.Services
{
    public interface IAuditService
    {
        void LogChanges(DbContext context, string userId, string userName = null, string ipAddress = null, string userAgent = null, string sessionId = null);
        IQueryable<AuditEntry> GetAuditEntries(string tableName = null, string userId = null, DateTime? fromDate = null, DateTime? toDate = null);
    }

    public class AuditService : IAuditService
    {
        public void LogChanges(DbContext context, string userId, string userName = null, string ipAddress = null, string userAgent = null, string sessionId = null)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged && e.State != EntityState.Detached)
                .ToList();

            foreach (var entry in entries)
            {
                var auditEntry = CreateAuditEntry(entry, userId, userName, ipAddress, userAgent, sessionId);
                if (auditEntry != null)
                {
                    context.Set<AuditEntry>().Add(auditEntry);
                }
            }
        }

        public IQueryable<AuditEntry> GetAuditEntries(string tableName = null, string userId = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            // This would need to be implemented in the repository/infrastructure layer
            // For now, return empty query
            return Enumerable.Empty<AuditEntry>().AsQueryable();
        }

        private AuditEntry CreateAuditEntry(EntityEntry entry, string userId, string userName, string ipAddress, string userAgent, string sessionId)
        {
            if (entry.Entity is AuditEntry) return null; // Don't audit audit entries

            var auditEntry = new AuditEntry
            {
                TableName = entry.Metadata.Name,
                Action = entry.State.ToString(),
                UserId = userId,
                UserName = userName ?? userId,
                IpAddress = ipAddress ?? "Unknown",
                UserAgent = userAgent ?? "Unknown",
                SessionId = sessionId ?? "Unknown",
                Timestamp = DateTime.UtcNow,
                KeyValues = GetKeyValues(entry),
                OldValues = entry.State == EntityState.Modified ? GetOldValues(entry) : null,
                NewValues = GetNewValues(entry)
            };

            return auditEntry;
        }

        private string GetKeyValues(EntityEntry entry)
        {
            var keyValues = new Dictionary<string, object>();
            foreach (var property in entry.Metadata.FindPrimaryKey().Properties)
            {
                var propertyName = property.Name;
                var propertyValue = entry.Property(propertyName).CurrentValue;
                keyValues[propertyName] = propertyValue;
            }
            return JsonSerializer.Serialize(keyValues);
        }

        private string GetOldValues(EntityEntry entry)
        {
            var oldValues = new Dictionary<string, object>();
            foreach (var property in entry.Properties.Where(p => p.IsModified))
            {
                oldValues[property.Metadata.Name] = property.OriginalValue;
            }
            return JsonSerializer.Serialize(oldValues);
        }

        private string GetNewValues(EntityEntry entry)
        {
            var newValues = new Dictionary<string, object>();
            foreach (var property in entry.Properties)
            {
                if (entry.State == EntityState.Deleted)
                {
                    newValues[property.Metadata.Name] = property.OriginalValue;
                }
                else
                {
                    newValues[property.Metadata.Name] = property.CurrentValue;
                }
            }
            return JsonSerializer.Serialize(newValues);
        }
    }
}