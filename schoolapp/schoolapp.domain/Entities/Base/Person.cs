namespace schoolapp.Domain.Entities.Base;

public abstract class Person : BaseAuditableEntity
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public DateTime DOB { get; set; }
    public string Status { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTimeOffset Joined { get; set; }
    public int SchoolId { get; set; }
    public virtual School School { get; set; }
}
