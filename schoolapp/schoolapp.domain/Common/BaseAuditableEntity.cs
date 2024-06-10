using schoolapp.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Domain.Common;

public abstract class BaseAuditableEntity 
{
    public DateTimeOffset Created { get; set; }
    public string CreatedByUserId { get; set; }
    [NotMapped]
    public virtual AppUser CreatedByUser { get; set; }

    public DateTimeOffset? LastModified { get; set; }

    public string? LastModifiedByUserId { get; set; }
    [NotMapped]
    public virtual AppUser LastModifiedByUser { get; set; }
}
