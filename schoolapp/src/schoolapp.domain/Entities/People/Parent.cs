using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Parent : Person
    {
        public List<Student> Students { get; set; } = [];
        public List<StudentParent> StudentParents { get; set; } = [];
        public School School { get; set; }
        
        // Additional parent information
        public string? Occupation { get; set; }
        public string? Workplace { get; set; }
        public ParentType RelationshipToStudent { get; set; } = ParentType.Guardian;
        public string? AlternatePhone { get; set; }
        public string? AlternateEmail { get; set; }

        public Parent(string firstName, string lastName, string phone, int schoolId, Gender gender) : base(firstName, lastName, schoolId, gender)
        {
            Phone = phone?.Trim();
        }
        
        public static Parent? Create(string firstName, string lastName, string phone, int schoolId, Gender gender)
        {
            return new Parent(firstName, lastName, phone, schoolId, gender);
        }
    }
}
