using System;

namespace schoolapp.Domain.Common
{
    public class AuditEntry : BaseAuditableEntity
    {
        public string TableName { get; set; }
        public string Action { get; set; } // INSERT, UPDATE, DELETE
        public string KeyValues { get; set; } // JSON of primary key values
        public string OldValues { get; set; } // JSON of old values
        public string NewValues { get; set; } // JSON of new values
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
    }
}