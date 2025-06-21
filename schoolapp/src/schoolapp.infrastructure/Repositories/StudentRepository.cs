using Microsoft.EntityFrameworkCore;
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
                        Status = s.Status.ToString(),
                        FullName = s.FullName,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        OtherName = s.OtherNames,
                        DOB = s.DateOfBirth,
                        ClassroomId = s.ClassRoomId,
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
                Status = s.Status.ToString(),
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
        
    }
}
