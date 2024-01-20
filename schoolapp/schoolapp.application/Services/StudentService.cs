using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ISchoolDbContext _context;

        public StudentService(ISchoolDbContext context)
        {
            _context = context;
        }      

        public async Task<Student?> GetStudent(int id, int schoolId)
        {
            var student =  await _context.Students.FindAsync(id);
            return student == null ? null : student;
        }

        public async Task<IEnumerable<Student>?> GetStudents(int schoolId)
        {
            var students = await _context.Students.Where(s=>s.SchoolId==schoolId).ToListAsync();
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

        public async Task<Student?> PutStudent(int id, Student Student, CancellationToken cancellationToken)
        {
            if (id != Student.Id)
            {
                return null;
            }
            var student = await _context.Students.FindAsync(new object[] { id }, cancellationToken);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
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
        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
