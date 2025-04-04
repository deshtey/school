using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Domain.Entities.Academics
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int SchoolId { get; set; }
        public string SubjectName { get; set; }
        public string? Desc { get; set; }
        public bool Elective { get; set; } = false;

        public School School { get; set; }
        public ICollection<ClassRoomSubject> GradeSubjects { get; set; } = new List<ClassRoomSubject>();

        public SchoolSubject() { }
        public SchoolSubject(int schoolId, string code, string name, bool Elective, string desc)
        {
            SchoolId = schoolId;
            Code = code;
            SubjectName = name;
            Elective = Elective;
            Desc = desc;
        }

        public override string ToString() => $"{Code}: {SubjectName}";
    }
}
