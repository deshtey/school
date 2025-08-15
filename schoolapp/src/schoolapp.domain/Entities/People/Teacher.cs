using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Departments;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        protected Teacher() { }
        public Teacher(string firstName, string lastname, int schoolId, Gender gender) : base(firstName, lastname, schoolId, gender)
        {
            SubjectsQualified = new List<SchoolSubject>();
            ClassesResponsibleFor = new List<ClassRoom>();
        }

        public string? TeacherId { get; set; }
        public string? RegNo { get; set; }
        public List<Department> Departments { get; set; }
        public List<SchoolSubject> SubjectsQualified { get; set; } = [];

        // Professional information
        public string? Qualifications { get; set; }
        public string? Certifications { get; set; }
        public DateTime? EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public string? SpecializationAreas { get; set; }
        public int YearsOfExperience { get; set; }

        // Financial information
        public decimal? Salary { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }

        public List<ClassRoom> ClassesResponsibleFor { get; set; } = new List<ClassRoom>();

        public void AssignAsClassTeacher(ClassRoom classroom)
        {
            classroom.ClassTeacher = this;
            if (!ClassesResponsibleFor.Contains(classroom))
            {
                ClassesResponsibleFor.Add(classroom);
            }
        }

    }
}
