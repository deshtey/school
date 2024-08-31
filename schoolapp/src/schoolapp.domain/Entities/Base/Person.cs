namespace schoolapp.Domain.Entities.Base;

public abstract class Person : BaseAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? DOB { get; set; }
    public string? Status { get; set; } = "active";
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
}
