using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.StudentAcademics;
using schoolapp.Domain.Exceptions;

namespace schoolapp.Domain.Entities.People
{
    [Index(nameof(SchoolId), nameof(StudentStatus))]
    [Index(nameof(ClassRoomId), nameof(StudentStatus))]
    [Index(nameof(EnrollmentYearId), nameof(StudentStatus))]
    [Index(nameof(RegNumber), IsUnique = true)]
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

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Registration number must be uppercase alphanumeric")]

        public string RegNumber { get; init; }

        public int? ClassRoomId { get; set; }
        public virtual ClassRoom? ClassRoom { get; set; }
        public virtual List<Parent> Parents { get; private set; }
        public virtual List<StudentParent> StudentParents { get; private set; }
        public virtual AcademicYear? EnrollmentYear { get; set; }
        public int? EnrollmentYearId { get; set; }
        public virtual List<StudentSubject> EnrolledSubjects { get; private set; }
        public virtual List<AcademicRecord> AcademicHistory { get; private set; }

        // Emergency contact information
        [StringLength(100)]
        public string? EmergencyContactName { get; set; }

        [Phone]
        [StringLength(20)]
        public string? EmergencyContactPhone { get; set; }

        [StringLength(50)]
        public string? EmergencyContactRelationship { get; set; }

        // Medical information
        [StringLength(500)]
        public string? MedicalConditions { get; set; }

        [StringLength(500)]
        public string? Allergies { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood group format")]
        public string? BloodGroup { get; set; }

        // Personal information
        [StringLength(50)]
        public string? Religion { get; set; }

        [StringLength(50)]
        public string? Nationality { get; set; }

        // Academic information
        [DataType(DataType.Date)]
        public DateTime? AdmissionDate { get; set; }

        [StringLength(200)]
        public string? PreviousSchool { get; set; }

        // Student status
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Active;
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
            ClassRoom initialClass,
            Gender gender = Gender.Unknown)
        {
            var student = new Student(firstName, lastName, schoolId, regNumber, gender)
            {
                EnrollmentYear = enrollmentYear ?? throw new ArgumentNullException(nameof(enrollmentYear)),
                ClassRoom = initialClass ?? throw new ArgumentNullException(nameof(initialClass)),
                ClassRoomId = initialClass.Id,
                StudentStatus = StudentStatus.Active
            };

            return student;
        }

        // Enroll in a subject with validation
        public void EnrollInSubject(SchoolSubject subject, AcademicYear academicYear)
        {
            ValidateSubjectEnrollment(subject, academicYear);

            var studentSubject = new StudentSubject
            {
                Student = this,
                Subject = subject,
                AcademicYear = academicYear,
                EnrollmentDate = DateTime.UtcNow
            };

            EnrolledSubjects.Add(studentSubject);
        }

        private void ValidateSubjectEnrollment(SchoolSubject subject, AcademicYear academicYear)
        {
            if (subject == null)
                throw new BusinessRuleException("Subject cannot be null");

            if (academicYear == null)
                throw new BusinessRuleException("Academic year cannot be null");

            if (StudentStatus != StudentStatus.Active)
                throw new BusinessRuleException("Cannot enroll inactive student in subjects");

            if (IsAlreadyEnrolled(subject.Id, academicYear.Id))
                throw new BusinessRuleException($"Student is already enrolled in {subject.Name} for academic year {academicYear.Name}");

            if (EnrolledSubjects.Count(es => es.AcademicYear.Id == academicYear.Id) >= GetMaxSubjectsPerYear())
                throw new BusinessRuleException("Maximum subjects per academic year exceeded");
        }

        private int GetMaxSubjectsPerYear()
        {
            // This could be configurable based on grade level
            return ClassRoom?.Grade?.MaxSubjectsPerYear ?? 8;
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

            if (ClassRoom == null)
                return false;

            if (StudentStatus != StudentStatus.Active)
                return false;

            var currentSubjects = GetCurrentSubjects(academicYear)
                .Where(es => es.FinalGrade.HasValue)
                .ToList();

            if (!currentSubjects.Any())
                return false;

            // Check minimum overall grade
            double overallGrade = CalculateOverallGrade(academicYear);
            if (overallGrade < ClassRoom.Grade.MinimumOverallGradeForPromotion)
                return false;

            // Additional validation logic can be added here
            // Check compulsory subjects, minimum subjects taken, etc.

            return true;
        }

        // Promote student to next grade
        public void PromoteToGrade(ClassRoom newClass, AcademicYear newAcademicYear)
        {
            if (newClass == null)
                throw new ArgumentNullException(nameof(newClass));

            if (newAcademicYear == null)
                throw new ArgumentNullException(nameof(newAcademicYear));

            if (!IsEligibleForPromotion(newAcademicYear))
                throw new InvalidOperationException("Student is not eligible for promotion");

            // Record the promotion in academic history
            var academicRecord = new AcademicRecord
            {
                Student = this,
                AcademicYear = newAcademicYear,
                PreviousGrade = ClassRoom.Grade,
                NewGrade = newClass.Grade,
                PromotionDate = DateTime.UtcNow,
                OverallGrade = CalculateOverallGrade(newAcademicYear)
            };

            AcademicHistory.Add(academicRecord);
            ClassRoom = newClass;
        }

        // Graduate student
        public void Graduate(DateTime graduationDate)
        {
            if (StudentStatus != StudentStatus.Active)
                throw new InvalidOperationException("Only active students can graduate");

            StudentStatus = StudentStatus.Graduated;
            GraduationDate = graduationDate;
        }

        // Withdraw student
        public void Withdraw(string reason, DateTime? withdrawalDate = null)
        {
            if (StudentStatus != StudentStatus.Active)
                throw new InvalidOperationException("Only active students can be withdrawn");

            StudentStatus = StudentStatus.Withdrawn;
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
    public enum StudentStatus : short
    {
        Active=1,
        Graduated=2,
        Withdrawn=3,
        Suspended=4,
        Transferred=5
    }

    public enum ParentType : byte
    {
        Father=1,
        Mother=2,
        Guardian=3,
        Emergency=4
    }

    // Builder pattern for complex student creation
    public class StudentBuilder
    {
        private string _firstName;
        private string _lastName;
        private int _schoolId;
        private string _regNumber;
        private AcademicYear _enrollmentYear;
        private ClassRoom _initialClass;
        private Gender _gender = Gender.Unknown;
        private DateTime? _dateOfBirth;
        private string _email;
        private string _phone;
        private List<(Parent parent, ParentType type)> _parents = new();
        private string? _emergencyContactName;
        private string? _emergencyContactPhone;
        private string? _emergencyContactRelationship;
        private string? _medicalConditions;
        private string? _allergies;
        private string? _bloodGroup;
        private string? _religion;
        private string? _nationality;
        private DateTime? _admissionDate;
        private string? _previousSchool;

        public StudentBuilder WithBasicInfo(string firstName, string lastName, int schoolId, string regNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _schoolId = schoolId;
            _regNumber = regNumber;
            return this;
        }

        public StudentBuilder WithAcademicInfo(AcademicYear enrollmentYear, ClassRoom initialClass)
        {
            _enrollmentYear = enrollmentYear;
            _initialClass = initialClass;
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

        public StudentBuilder WithEmergencyContact(string? emergencyContactName, string? emergencyContactPhone, string? emergencyContactRelationship)
        {
            _emergencyContactName = emergencyContactName;
            _emergencyContactPhone = emergencyContactPhone;
            _emergencyContactRelationship = emergencyContactRelationship;
            return this;
        }

        public StudentBuilder WithMedicalInfo(string? medicalConditions, string? allergies, string? bloodGroup)
        {
            _medicalConditions = medicalConditions;
            _allergies = allergies;
            _bloodGroup = bloodGroup;
            return this;
        }

        public StudentBuilder WithPersonalInfo(Gender gender, DateTime? dateOfBirth = null, string email = null, string phone = null, string? religion = null, string? nationality = null)
        {
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            _email = email;
            _phone = phone;
            _religion = religion;
            _nationality = nationality;
            return this;
        }

        public StudentBuilder WithAcademicInfo(AcademicYear enrollmentYear, ClassRoom initialClass, DateTime? admissionDate = null, string? previousSchool = null)
        {
            _enrollmentYear = enrollmentYear;
            _initialClass = initialClass;
            _admissionDate = admissionDate;
            _previousSchool = previousSchool;
            return this;
        }

        public Student Build()
        {
            var student = Student.Create(_firstName, _lastName, _schoolId, _regNumber, _enrollmentYear, _initialClass, _gender);

            if (_dateOfBirth.HasValue)
                student.DateOfBirth = _dateOfBirth;

            if (!string.IsNullOrWhiteSpace(_email))
                student.Email = _email;

            if (!string.IsNullOrWhiteSpace(_phone))
                student.Phone = _phone;

            // Set emergency contact information
            if (!string.IsNullOrWhiteSpace(_emergencyContactName))
                student.EmergencyContactName = _emergencyContactName;
            
            if (!string.IsNullOrWhiteSpace(_emergencyContactPhone))
                student.EmergencyContactPhone = _emergencyContactPhone;
            
            if (!string.IsNullOrWhiteSpace(_emergencyContactRelationship))
                student.EmergencyContactRelationship = _emergencyContactRelationship;

            // Set medical information
            if (!string.IsNullOrWhiteSpace(_medicalConditions))
                student.MedicalConditions = _medicalConditions;
            
            if (!string.IsNullOrWhiteSpace(_allergies))
                student.Allergies = _allergies;
            
            if (!string.IsNullOrWhiteSpace(_bloodGroup))
                student.BloodGroup = _bloodGroup;

            // Set personal information
            if (!string.IsNullOrWhiteSpace(_religion))
                student.Religion = _religion;
            
            if (!string.IsNullOrWhiteSpace(_nationality))
                student.Nationality = _nationality;

            // Set academic information
            if (_admissionDate.HasValue)
                student.AdmissionDate = _admissionDate;
            
            if (!string.IsNullOrWhiteSpace(_previousSchool))
                student.PreviousSchool = _previousSchool;

            foreach (var (parent, parentType) in _parents)
            {
                student.AddParent(parent, parentType);
            }

            return student;
        }
    }
}