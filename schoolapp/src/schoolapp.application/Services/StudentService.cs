using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<StudentService> _logger;
        public StudentService(ISchoolDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<StudentParentDto>?> GetStudents(int schoolId)
        {
            try
            {
                var students = await _context.Students
               .Where(s => s.SchoolId == schoolId)
               .Select(s => new StudentParentDto
               {
                   Id = s.Id,
                   SchoolId = s.SchoolId,
                   StudentDto = new StudentDto
                   {
                       Status = s.Status,
                       FirstName = s.GetFullName(),
                       DOB = s.DOB,
                       Email = s.Email,
                       Gender = s.Gender,
                       Phone = s.Phone,
                       RegNumber = s.RegNumber
                   },
                   ParentsDto = s.Parents.Select(p => new ParentDto
                   {
                       Id = p.Id,
                       FullName = p.GetFullName(),
                       Email = p.Email,
                       Phone = p.Phone,
                   }).ToList()

               })
               .ToListAsync();
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

            var student = await _context.Students
                .Where(s => s.Id == id && s.SchoolId == schoolId)
                .Select(s => new StudentParentDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    StudentDto = new StudentDto
                    {
                        Status = s.Status,
                        FullName = s.GetFullName(),
                        DOB = s.DOB,
                        ClassroomId = s.ClassRoomId,
                        Email = s.Email,
                        Gender = s.Gender,
                        Phone = s.Phone,
                        RegNumber = s.RegNumber ,
                        StudentClass=s.StudentClass.ClassroomName
                    },
                    ParentsDto = s.Parents.Select(p => new ParentDto
                    {
                        Id = p.Id,
                        FullName = p.GetFullName(),
                        Email = p.Email,
                        Phone = p.Phone,
                    }).ToList()
                }).FirstOrDefaultAsync();

            return student?? null;
        }

        public async Task<Student?> PostStudent(StudentParentDto studentparentDto, CancellationToken cancellationToken)
        {
            if (_context.Students == null)
            {
                return null;
            }
            int schoolId = studentparentDto.SchoolId;
            Student _student = new()
            {
                Active = true,
                SchoolId = schoolId,
                FirstName = studentparentDto.StudentDto.FirstName,
                LastName = studentparentDto.StudentDto.LastName,
                OtherNames = studentparentDto.StudentDto.OtherName,
                Email = studentparentDto.StudentDto.Email,
                ClassRoomId = studentparentDto.StudentDto.ClassroomId??null,
                Gender = studentparentDto.StudentDto.Gender,
                RegNumber = studentparentDto.StudentDto.RegNumber,
                Image = studentparentDto.StudentDto.ImageUrl
            };

            //using var transaction = _context.BeginTransactionAsync();
           

            _context.Students.Add(_student);
            await _context.SaveChangesAsync(cancellationToken);
            foreach(var _parent in studentparentDto.ParentsDto)
            {
                Parent parent = await _context.Parents.FirstOrDefaultAsync(p => p.Email == _parent.Email, cancellationToken);
                if (parent == null)
                {
                    parent = new Parent
                    {
                        Active = true,
                        Email = _parent.Email,
                        Gender = _parent.Gender,
                        Phone = _parent.Phone,
                        FirstName = _parent.FirstName,
                        LastName = _parent.LastName,
                        OtherNames = _parent.OtherName,
                        SchoolId = schoolId,
                    };
                    _context.Parents.Add(parent);
                    await _context.SaveChangesAsync(cancellationToken);
                    // Insert the relationship in the StudentParents table

                }
                var studentParent = new StudentParent
                {
                    StudentId = _student.Id,
                    ParentId = parent.Id
                };
                _context.StudentParents.Add(studentParent);
                await _context.SaveChangesAsync(cancellationToken);
            }
         
            return _student;
        }

        public async Task<Student?> PutStudent(int id, StudentParentDto student, CancellationToken cancellationToken)
        {
            if (student == null || id != student.Id)
            {
                return null;
            }

            try
            {
                var existingStudent = await _context.Students.FindAsync(new object[] { id }, cancellationToken);

                if (existingStudent == null)
                {
                    return null; // Student with the given ID not found.
                }

                _context.Students.Entry(existingStudent).CurrentValues.SetValues(student);

                await _context.SaveChangesAsync(cancellationToken);

                return existingStudent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student");
                return null;
            }
        }

        public async Task<bool> DeleteStudent(int id, CancellationToken cancellationToken)
        {
            if (_context.Students == null)
            {
                return false;
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return true;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        Task<StudentParentDto?> IStudentService.PutStudent(int id, StudentParentDto Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

   
    }
}
