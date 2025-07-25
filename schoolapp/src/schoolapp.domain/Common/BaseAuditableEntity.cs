﻿namespace schoolapp.Domain.Common;

public abstract class BaseAuditableEntity 
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public string CreatedByUserId { get; set; }
    public DateTimeOffset? LastModified { get; set; } = DateTimeOffset.UtcNow;
    public string? LastModifiedByUserId { get; set; }
    public EntityStatus Status { get; set; } = EntityStatus.Active;
}
