using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities
{
    public class School : BaseAuditableEntity
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public Address Address { get; set; }
        public string HomePage { get; set; } = string.Empty;

    }
}
