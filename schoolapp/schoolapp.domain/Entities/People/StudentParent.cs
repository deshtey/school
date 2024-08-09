
namespace schoolapp.Domain.Entities.People
{
    public class StudentParent
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public RelationshipType RelationshipType { get; set; }

    }
    public enum RelationshipType
    {
        Mother =1,
        Father=2,
        Sibling=3,
        Guardian=4,
        Other=5
    }
}
