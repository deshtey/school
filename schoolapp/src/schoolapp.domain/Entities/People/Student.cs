using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.StudentAcademics;

namespace schoolapp.Domain.Entities.People
{
    public class Student : Person
    {
        public string RegNumber { get; set; }
        public int? ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public List<Parent> Parents { get; set; } = [];
        public List<StudentParent> StudentParents { get; set; } = [];
        public Grade CurrentGrade { get; set; }
        public AcademicYear EnrollmentYear { get; set; }
        public List<StudentSubject> EnrolledSubjects { get; set; } = new List<StudentSubject>();
        public List<AcademicRecord> AcademicHistory { get; set; } = new List<AcademicRecord>();


        public Student()
        {
            EnrolledSubjects = new List<StudentSubject>();
            AcademicHistory = new List<AcademicRecord>();
        }

        // Enroll in a subject
        public void EnrollInSubject(SchoolSubject subject, AcademicYear academicYear)
        {
            if (EnrolledSubjects.Any(es => es.Subject.Id == subject.Id && es.AcademicYear.Id == academicYear.Id))
            {
                throw new InvalidOperationException("Student is already enrolled in this subject for the given academic year");
            }

            EnrolledSubjects.Add(new StudentSubject
            {
                Student = this,
                Subject = subject,
                AcademicYear = academicYear
            });
        }

        // Get the student's current enrolled subjects
        public List<StudentSubject> GetCurrentSubjects(AcademicYear currentYear)
        {
            return EnrolledSubjects.Where(es => es.AcademicYear.Id == currentYear.Id).ToList();
        }

        // Calculate overall grade for the academic year
        public double CalculateOverallGrade(AcademicYear academicYear)
        {
            var relevantSubjects = EnrolledSubjects
                .Where(es => es.AcademicYear.Id == academicYear.Id && es.FinalGrade.HasValue)
                .ToList();

            if (!relevantSubjects.Any())
                return 0;

            return relevantSubjects.Average(es => es.FinalGrade.Value);
        }

        // Check if student is eligible for promotion
        public bool IsEligibleForPromotion(AcademicYear academicYear)
        {
            // Get all subjects for the current academic year with grades
            var currentSubjects = EnrolledSubjects
                .Where(es => es.AcademicYear.Id == academicYear.Id && es.FinalGrade.HasValue)
                .ToList();

            if (!currentSubjects.Any())
                return false;

            // Calculate overall grade
            double overallGrade = CalculateOverallGrade(academicYear);

            // Check if overall grade meets minimum requirement
            if (overallGrade < CurrentGrade.MinimumOverallGradeForPromotion)
                return false;

            // Check compulsory subjects
            //var compulsorySubjects = currentSubjects
            //    .Where(es => es.Subject.Eli == false)
            //    .ToList();

            // Ensure all compulsory subjects have been taken
            //if (compulsorySubjects.Count < CurrentGrade.CompulsorySubjects.Count)
            //    return false;

            // Check if any compulsory subject has a grade below the minimum requirement
            //if (compulsorySubjects.Any(es => es.FinalGrade < CurrentGrade.MinimumGradePerCompulsorySubject))
            //    return false;

            //// Check if student has taken the minimum required optional subjects
            //var optionalSubjects = currentSubjects
            //    .Where(es => es.Subject.Elective)
            //    .ToList();

            //if (optionalSubjects.Count < CurrentGrade.MinOptionalSubjectsRequired)
            //    return false;

            return true;
        }
    }
}
