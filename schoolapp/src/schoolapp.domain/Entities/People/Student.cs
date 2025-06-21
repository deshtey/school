using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.StudentAcademics;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Domain.Entities.People
{
    public class Student : Person
    {
        private Student(string firstName, string lastName, int schoolId, string regNumber, Gender gender = Gender.Unknown)
            : base(firstName, lastName, schoolId, gender)
        {
            RegNumber = !string.IsNullOrWhiteSpace(regNumber)
                ? regNumber.Trim().ToUpper()
                : throw new ArgumentException("Registration number cannot be null or empty.", nameof(regNumber));

            Parents = new List<Parent>();
            StudentParents = new List<StudentParent>();
            EnrolledSubjects = new List<StudentSubject>();
            AcademicHistory = new List<AcademicRecord>();
        }
        public string RegNumber { get; init; }
        public int? ClassRoomId { get; set; }
        public virtual ClassRoom? ClassRoom { get; set; }
        public virtual List<Parent> Parents { get; private set; }
        public virtual List<StudentParent> StudentParents { get; private set; }
        public virtual Grade? CurrentGrade { get; set; }
        public virtual AcademicYear? EnrollmentYear { get; set; }
        public virtual List<StudentSubject> EnrolledSubjects { get; private set; }
        public virtual List<AcademicRecord> AcademicHistory { get; private set; }

        // Student status
        public StudentStatus Status { get; set; } = StudentStatus.Active;
        public DateTime? GraduationDate { get; set; }
        public DateTime? WithdrawalDate { get; set; }
        public string? WithdrawalReason { get; set; }

        // Factory method for creating new students
        public static Student Create(
            string firstName,
            string lastName,
            int schoolId,
            string regNumber,
            AcademicYear enrollmentYear,
            Grade initialGrade,
            Gender gender = Gender.Unknown)
        {
            var student = new Student(firstName, lastName, schoolId, regNumber, gender)
            {
                EnrollmentYear = enrollmentYear ?? throw new ArgumentNullException(nameof(enrollmentYear)),
                CurrentGrade = initialGrade ?? throw new ArgumentNullException(nameof(initialGrade)),
                Status = StudentStatus.Active
            };

            return student;
        }

        // Enroll in a subject with validation
        public void EnrollInSubject(SchoolSubject subject, AcademicYear academicYear)
        {
            if (subject == null)
                throw new ArgumentNullException(nameof(subject));

            if (academicYear == null)
                throw new ArgumentNullException(nameof(academicYear));

            if (Status != StudentStatus.Active)
                throw new InvalidOperationException("Cannot enroll inactive student in subjects");

            if (IsAlreadyEnrolled(subject.Id, academicYear.Id))
                throw new InvalidOperationException($"Student is already enrolled in {subject.Name} for academic year {academicYear.Name}");

            var studentSubject = new StudentSubject
            {
                Student = this,
                Subject = subject,
                AcademicYear = academicYear,
                EnrollmentDate = DateTime.UtcNow
            };

            EnrolledSubjects.Add(studentSubject);
        }

        // Withdraw from a subject
        public void WithdrawFromSubject(int subjectId, int academicYearId, string reason = null)
        {
            var enrollment = EnrolledSubjects
                .FirstOrDefault(es => es.Subject.Id == subjectId && es.AcademicYear.Id == academicYearId);

            if (enrollment == null)
                throw new InvalidOperationException("Student is not enrolled in this subject for the given academic year");

            enrollment.WithdrawalDate = DateTime.UtcNow;
            enrollment.WithdrawalReason = reason;
        }

        // Get current active subjects
        public List<StudentSubject> GetCurrentSubjects(AcademicYear currentYear)
        {
            if (currentYear == null)
                throw new ArgumentNullException(nameof(currentYear));

            return EnrolledSubjects
                .Where(es => es.AcademicYear.Id == currentYear.Id && !es.WithdrawalDate.HasValue)
                .ToList();
        }

        // Calculate overall grade for the academic year
        public double CalculateOverallGrade(AcademicYear academicYear)
        {
            if (academicYear == null)
                throw new ArgumentNullException(nameof(academicYear));

            var relevantSubjects = EnrolledSubjects
                .Where(es => es.AcademicYear.Id == academicYear.Id
                           && es.FinalGrade.HasValue
                           && !es.WithdrawalDate.HasValue)
                .ToList();

            return relevantSubjects.Any() ? relevantSubjects.Average(es => es.FinalGrade!.Value) : 0;
        }

        // Get GPA for academic year
        public double GetGPA(AcademicYear academicYear)
        {
            if (academicYear == null)
                throw new ArgumentNullException(nameof(academicYear));

            var relevantSubjects = EnrolledSubjects
                .Where(es => es.AcademicYear.Id == academicYear.Id
                           && es.FinalGrade.HasValue
                           && !es.WithdrawalDate.HasValue)
                .ToList();

            if (!relevantSubjects.Any())
                return 0;

            // Calculate weighted GPA if subjects have credit hours
            var totalCredits = relevantSubjects.Sum(es => es.Subject.CreditHours ?? 1);
            var totalGradePoints = relevantSubjects.Sum(es => (es.FinalGrade!.Value * (es.Subject.CreditHours ?? 1)));

            return totalGradePoints / totalCredits;
        }

        // Check promotion eligibility with improved logic
        public bool IsEligibleForPromotion(AcademicYear academicYear)
        {
            if (academicYear == null)
                throw new ArgumentNullException(nameof(academicYear));

            if (CurrentGrade == null)
                return false;

            if (Status != StudentStatus.Active)
                return false;

            var currentSubjects = GetCurrentSubjects(academicYear)
                .Where(es => es.FinalGrade.HasValue)
                .ToList();

            if (!currentSubjects.Any())
                return false;

            // Check minimum overall grade
            double overallGrade = CalculateOverallGrade(academicYear);
            if (overallGrade < CurrentGrade.MinimumOverallGradeForPromotion)
                return false;

            // Additional validation logic can be added here
            // Check compulsory subjects, minimum subjects taken, etc.

            return true;
        }

        // Promote student to next grade
        public void PromoteToGrade(Grade newGrade, AcademicYear newAcademicYear)
        {
            if (newGrade == null)
                throw new ArgumentNullException(nameof(newGrade));

            if (newAcademicYear == null)
                throw new ArgumentNullException(nameof(newAcademicYear));

            if (!IsEligibleForPromotion(newAcademicYear))
                throw new InvalidOperationException("Student is not eligible for promotion");

            // Record the promotion in academic history
            var academicRecord = new AcademicRecord
            {
                Student = this,
                AcademicYear = newAcademicYear,
                PreviousGrade = CurrentGrade,
                NewGrade = newGrade,
                PromotionDate = DateTime.UtcNow,
                OverallGrade = CalculateOverallGrade(newAcademicYear)
            };

            AcademicHistory.Add(academicRecord);
            CurrentGrade = newGrade;
        }

        // Graduate student
        public void Graduate(DateTime graduationDate)
        {
            if (Status != StudentStatus.Active)
                throw new InvalidOperationException("Only active students can graduate");

            Status = StudentStatus.Graduated;
            GraduationDate = graduationDate;
        }

        // Withdraw student
        public void Withdraw(string reason, DateTime? withdrawalDate = null)
        {
            if (Status != StudentStatus.Active)
                throw new InvalidOperationException("Only active students can be withdrawn");

            Status = StudentStatus.Withdrawn;
            WithdrawalDate = withdrawalDate ?? DateTime.UtcNow;
            WithdrawalReason = reason;
        }

        // Add parent relationship
        public void AddParent(Parent parent, ParentType parentType = ParentType.Guardian)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            if (StudentParents.Any(sp => sp.ParentId == parent.Id))
                throw new InvalidOperationException("Parent is already associated with this student");

            var studentParent = new StudentParent
            {
                Student = this,
                Parent = parent,
                ParentType = parentType,
                CreatedDate = DateTime.UtcNow
            };

            StudentParents.Add(studentParent);
            if (!Parents.Contains(parent))
                Parents.Add(parent);
        }

        // Helper methods
        private bool IsAlreadyEnrolled(int subjectId, int academicYearId)
        {
            return EnrolledSubjects.Any(es => es.Subject.Id == subjectId
                                            && es.AcademicYear.Id == academicYearId
                                            && !es.WithdrawalDate.HasValue);
        }

        public override string ToString() => $"{FullName} ({RegNumber})";
    }

    // Enums for better type safety
    public enum StudentStatus
    {
        Active,
        Graduated,
        Withdrawn,
        Suspended,
        Transferred
    }

    public enum ParentType
    {
        Father,
        Mother,
        Guardian,
        Emergency
    }

    // Builder pattern for complex student creation
    public class StudentBuilder
    {
        private string _firstName;
        private string _lastName;
        private int _schoolId;
        private string _regNumber;
        private AcademicYear _enrollmentYear;
        private Grade _initialGrade;
        private Gender _gender = Gender.Unknown;
        private DateTime? _dateOfBirth;
        private string _email;
        private string _phone;
        private List<(Parent parent, ParentType type)> _parents = new();

        public StudentBuilder WithBasicInfo(string firstName, string lastName, int schoolId, string regNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _schoolId = schoolId;
            _regNumber = regNumber;
            return this;
        }

        public StudentBuilder WithAcademicInfo(AcademicYear enrollmentYear, Grade initialGrade)
        {
            _enrollmentYear = enrollmentYear;
            _initialGrade = initialGrade;
            return this;
        }

        public StudentBuilder WithPersonalInfo(Gender gender, DateTime? dateOfBirth = null, string email = null, string phone = null)
        {
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            _email = email;
            _phone = phone;
            return this;
        }

        public StudentBuilder WithParent(Parent? parent, ParentType parentType = ParentType.Guardian)
        {
            if (parent != null) _parents.Add((parent, parentType));
            return this;
        }

        public Student Build()
        {
            var student = Student.Create(_firstName, _lastName, _schoolId, _regNumber, _enrollmentYear, _initialGrade, _gender);

            if (_dateOfBirth.HasValue)
                student.DateOfBirth = _dateOfBirth;

            if (!string.IsNullOrWhiteSpace(_email))
                student.Email = _email;

            if (!string.IsNullOrWhiteSpace(_phone))
                student.Phone = _phone;

            foreach (var (parent, parentType) in _parents)
            {
                student.AddParent(parent, parentType);
            }

            return student;
        }
    }
}