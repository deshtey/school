namespace schoolapp.Domain.Common;

public abstract class BaseAuditableEntity 
{
    public DateTimeOffset Created { get; set; }
    public string CreatedByUserId { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public string? LastModifiedByUserId { get; set; }
    public bool Active { get; set; }
}
