using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.People;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<StudentParentDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            //return await _context.Students
            //    .Include(s => s.Parents)
            //    .Include(s => s.StudentParents)
            //    .Include(s => s.CurrentGrade)
            //    .Include(s => s.EnrollmentYear)
            //    .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            return await _context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentParentDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    StudentDto = new StudentDto
                    {
                        Status = s.StudentStatus.ToString(),
                        FullName = s.FullName,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        OtherName = s.OtherNames,
                        DOB = s.DateOfBirth,
                        Email = s.Email,
                        Gender = s.Gender,
                        Phone = s.Phone,
                        RegNumber = s.RegNumber,
                        StudentClass = s.ClassRoom.Name
                    },
                    ParentsDto = s.Parents.Select(p => new ParentDto
                    {
                        Id = p.Id,
                        FullName = s.FullName,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        OtherName = s.OtherNames,
                        Email = p.Email,
                        Phone = p.Phone,
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Student?> GetByRegNumberAsync(string regNumber, int schoolId, CancellationToken cancellationToken = default)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.RegNumber == regNumber && s.SchoolId == schoolId, cancellationToken);
        }

        public async Task<bool> RegNumberExistsAsync(string regNumber, int schoolId, CancellationToken cancellationToken = default)
        {
            return await _context.Students
                .AnyAsync(s => s.RegNumber == regNumber && s.SchoolId == schoolId, cancellationToken);
        }

        public async Task AddAsync(Student student, CancellationToken cancellationToken = default)
        {
            await _context.Students.AddAsync(student, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task <IEnumerable<StudentDto>> GetStudentsBySchoolId(int schoolId)
        {
            return await _context.Students
           .Where(s => s.SchoolId == schoolId)
            .Select(s => new StudentDto
            {
                Id = s.Id,
                Status = s.StudentStatus.ToString(),
                FullName = s.FullName,
                FirstName = s.FirstName,
                LastName = s.LastName,
                OtherName = s.OtherNames,
                DOB = s.DateOfBirth,
                Email = s.Email,
                Gender = s.Gender,
                Phone = s.Phone,
                RegNumber = s.RegNumber
            })
           .ToListAsync();
        }


        public async Task<Result<Student>> UpdateStudentAsync( StudentDto studentDto, CancellationToken cancellationToken)
        {
         
            // Update the existing student with the values from the DTO
            //existingStudent.Status = Enum.Parse<StudentStatus>(studentDto.Status, true);
            //existingStudent.FirstName = studentDto.FirstName;
            //existingStudent.LastName = studentDto.LastName;
            //existingStudent.OtherNames = studentDto.OtherName;
            //existingStudent.DateOfBirth = studentDto.DOB;
            //existingStudent.Email = studentDto.Email;
            //existingStudent.Gender = studentDto.Gender;
                
            //_context.Students.Entry(existingStudent).CurrentValues.SetValues(student);

            //await _context.SaveChangesAsync(cancellationToken);

            //return existingStudent;
            await Task.Delay(1000, cancellationToken); // Simulate async operation
            throw new NotImplementedException("UpdateStudent method is not implemented yet.");
        }

        public async Task<Result<bool>> SoftDeleteStudent(int studentId, CancellationToken cancellationToken)
        {
            if (_context.Students == null)
            {
                return Result<bool>.Failure(["Contact sys Admin"]);
            }
            var student = await _context.Students.FindAsync(studentId, cancellationToken);
            if (student == null)
            {
                return Result<bool>.Success(true);
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }


    }
}
