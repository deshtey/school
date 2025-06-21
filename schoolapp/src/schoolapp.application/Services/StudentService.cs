using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Models;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.People;
using System.Net.Mail;

namespace schoolapp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAcademicRepository _academicRepository;
        private readonly IParentRepository _parentRepository;
        private readonly ILogger<StudentService> _logger;
        public StudentService(ILogger<StudentService> logger, IStudentRepository studentRepository, IAcademicRepository academicRepository, IParentRepository parentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _academicRepository = academicRepository;
            _parentRepository = parentRepository;
        }
        public async Task<Student> CreateStudentAsync(StudentParentDto request, CancellationToken cancellationToken = default)
        {
            // Validation
            var studentDto = request.StudentDto;
            var schoolId = request.SchoolId;
            await ValidateStudentCreationAsync(studentDto , schoolId, cancellationToken);

            // Get required academic entities
            var enrollmentYear = await _academicRepository.GetAcademicYearByIdAsync(studentDto.EnrollmentYearId, cancellationToken);
            if (enrollmentYear == null)
                throw new ArgumentNullException($"Academic year with ID {request} not found");

            var initialGrade = await _academicRepository.GetClassroomByIdAsync((int)studentDto.ClassroomId, cancellationToken);
            //if (initialGrade == null)
            //    throw new ArgumentNullException($"Grade with ID {request.InitialGradeId} not found");

            // Create student using builder
            var studentBuilder = new StudentBuilder()
                .WithBasicInfo(studentDto.FirstName, studentDto.LastName, request.SchoolId, studentDto.RegNumber)
                .WithAcademicInfo(enrollmentYear, initialGrade)
                .WithPersonalInfo(studentDto.Gender, studentDto.DateOfBirth, studentDto.Email, studentDto.Phone);

            // Handle parents
            var parents = await ProcessParentsAsync(request.ParentsDto, request.SchoolId, cancellationToken);

            foreach (var (parent, parentType) in parents)
            {
                studentBuilder.WithParent(parent, parentType);
            }

            var student = studentBuilder.Build();

            // Set other names if provided
            if (!string.IsNullOrWhiteSpace(studentDto.OtherName))
            {
                student.OtherNames = studentDto.OtherName.Trim();
            }

            // Persist to database
            await _studentRepository.AddAsync(student, cancellationToken);
            await _studentRepository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Student {RegNumber} created successfully with ID {StudentId}",
                student.RegNumber, student.Id);

            return student;
        }

        private async Task ValidateStudentCreationAsync(StudentDto request, int schoolId, CancellationToken cancellationToken)
        {
            // Check if registration number already exists
            if (await _studentRepository.RegNumberExistsAsync(request.RegNumber, schoolId, cancellationToken))
            {
                throw new ArgumentNullException($"Registration number {request.RegNumber} already exists in this school");
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(request.FirstName))
                throw new ArgumentNullException("First name is required");

            if (string.IsNullOrWhiteSpace(request.LastName))
                throw new ArgumentNullException("Last name is required");

            if (string.IsNullOrWhiteSpace(request.RegNumber))
                throw new ArgumentNullException("Registration number is required");

            // Validate email format if provided
            if (!string.IsNullOrWhiteSpace(request.Email) && !IsValidEmail(request.Email))
                throw new ArgumentNullException("Invalid email format");
        }

        private async Task<List<(Parent parent, ParentType parentType)>> ProcessParentsAsync(
            List<ParentDto> parentRequests,
            int schoolId,
            CancellationToken cancellationToken)
        {
            var result = new List<(Parent parent, ParentType parentType)>();

            foreach (var parentRequest in parentRequests)
            {
                Parent parent;

                // If existing parent ID is provided, use that
                if (parentRequest.Id.HasValue)
                {
                    parent = await _parentRepository.GetByIdAsync(parentRequest.Id.Value, cancellationToken);
                    if (parent == null)
                        throw new ArgumentNullException($"Parent with ID {parentRequest.Id.Value} not found");
                }
                else
                {
                    // Try to find existing parent by National ID or Email
                    parent = await FindExistingParentAsync(parentRequest, schoolId, cancellationToken);

                    // If not found, create new parent
                    if (parent == null)
                    {
                        parent = Parent.Create(
                            parentRequest.FirstName,
                            parentRequest.LastName,
                            parentRequest.Phone,
                            schoolId,
                            parentRequest.Gender.Value);

                        if (!string.IsNullOrWhiteSpace(parentRequest.Email))
                            parent.Email = parentRequest.Email.Trim().ToLower();

                        if (!string.IsNullOrWhiteSpace(parentRequest.NationalId))
                            parent.NationalId = parentRequest.NationalId.Trim();

                        await _parentRepository.AddAsync(parent, cancellationToken);
                    }
                }

                result.Add((parent, parentRequest.ParentType));
            }

            return result;
        }

        private async Task<Parent?> FindExistingParentAsync(
            ParentDto parentRequest,
            int schoolId,
            CancellationToken cancellationToken)
        {
            //// Try to find by National ID first
            //if (!string.IsNullOrWhiteSpace(parentRequest.NationalId))
            //{
            //    var existingParent = await _parentRepository.GetByNationalIdAsync(parentRequest.NationalId, schoolId, cancellationToken);
            //    if (existingParent != null)
            //        return existingParent;
            //}
            // Try to find by Phone No First
            if (!string.IsNullOrWhiteSpace(parentRequest.Phone))
            {
                var existingParent = await _parentRepository.GetByPhoneAsync(parentRequest.Phone, schoolId, cancellationToken);
                if (existingParent != null)
                    return existingParent;
            }

            // Try to find by Email
            if (!string.IsNullOrWhiteSpace(parentRequest.Email))
            {
                var existingParent = await _parentRepository.GetByEmailAsync(parentRequest.Email, schoolId, cancellationToken);
                if (existingParent != null)
                    return existingParent;
            }

            return null;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IEnumerable<StudentDto>?> GetStudents(int schoolId)
        {
            try
            {
                var students = await _studentRepository.GetStudentsBySchoolId(schoolId);
        
                return students;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching students");
                throw;
            }
        }

        public async Task<StudentParentDto?> GetStudent(int id, int schoolId)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching student");
                throw;
            }


        }
        public async Task<Student?> GetByRegNumberAsync(string regNumber, int schoolId, CancellationToken cancellationToken = default)
        {
            try
            {
                var student = await _studentRepository.GetByRegNumberAsync(regNumber, schoolId, cancellationToken);
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching student");
                throw;
            }
    
        }

        public async Task<bool> RegNumberExistsAsync(string regNumber, int schoolId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _studentRepository.RegNumberExistsAsync(regNumber, schoolId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Result<Student>> PutStudent(int id, StudentParentDto student, CancellationToken cancellationToken)
        {
            if (student == null || id != student.Id)
            {
                return null;
            }

            try
            {
                var existingStudent = await _studentRepository.GetByIdAsync(id, cancellationToken);

                if (existingStudent == null)
                {
                    return null; 
                }
                var updatedStudent = await _studentRepository.UpdateStudent(student.StudentDto, cancellationToken);
                return Result<Student>.Success( updatedStudent);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student");
                return Result<Student>.Failure(["Error updating student: " + ex.Message]);
            }
        }

        public async Task<bool> DeleteStudent(int id, CancellationToken cancellationToken)
        {


            return true;
        }
        //public bool PromoteToNextGrade(SchoolContext context, AcademicYear currentYear, AcademicYear nextYear)
        //{
        //    if (!IsEligibleForPromotion(currentYear))
        //        return false;

        //    Grade nextGrade = CurrentGrade.GetNextGrade(context);
        //    if (nextGrade == null)
        //        return false;

        //    // Create academic record for the completed grade
        //    AcademicHistory.Add(new AcademicRecord
        //    {
        //        Student = this,
        //        Grade = CurrentGrade,
        //        ClassRoom = ClassRoom,
        //        AcademicYear = currentYear,
        //        OverallGrade = CalculateOverallGrade(currentYear),
        //        CompletionDate = currentYear.EndDate
        //    });

        //    // Update student's current grade
        //    CurrentGrade = nextGrade;

        //    // Remove from current classroom
        //    if (ClassRoom != null)
        //    {
        //        ClassRoom.RemoveStudent(this);
        //    }

        //    // Student needs to be assigned to a new classroom in the next grade
        //    // This will be handled by the school administration separately

        //    // Enroll student in all compulsory subjects for the new grade
        //    foreach (var subject in nextGrade.CompulsorySubjects)
        //    {
        //        EnrollInSubject(subject, nextYear);
        //    }

        //    return true;
        //}

        Task<StudentParentDto?> IStudentService.PutStudent(int id, StudentParentDto Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

   
    }
}
