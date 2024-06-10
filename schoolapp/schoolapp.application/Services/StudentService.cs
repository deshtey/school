using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
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

        public async Task<Student?> GetStudent(int id, int schoolId)
        {
            var student =  await _context.Students.FindAsync(id);
            return student == null ? null : student;
        }

        public async Task<IEnumerable<Student>?> GetStudents(int schoolId)
        {
            var students = await _context.Students.Where(s=>s.SchoolId==schoolId)
                //.Include(s=>s.P)
                .ToListAsync();
            return students;
        }

        public async Task<bool?> PostStudent(Student student, CancellationToken cancellationToken)
        {
            if (_context.Students == null)
            {
                return null;
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Student?> PutStudent(int id, Student student, CancellationToken cancellationToken)
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

    }
}
