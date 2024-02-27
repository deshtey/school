using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<TeacherService> _logger;
        public TeacherService(ISchoolDbContext context, ILogger<TeacherService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Teacher>?> GetTeachers()
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetTeacher(int id)
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            var Teacher = await _context.Teachers.FindAsync(id);

            if (Teacher == null)
            {
                return null;
            }
            return Teacher;
        }

        public async Task<Teacher?> PutTeacher(int id, Teacher school, CancellationToken cancellationToken)
        {
            if (school == null || id != school.TeacherId)
            {
                return null;
            }

            try
            {
                var existingTeacher = await _context.Teachers.FindAsync(new object[] { id }, cancellationToken);

                if (existingTeacher == null)
                {
                    return null; // Teacher with the given ID not found.
                }

                _context.Teachers.Entry(existingTeacher).CurrentValues.SetValues(school);

                await _context.SaveChangesAsync(cancellationToken);

                return existingTeacher;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostTeacher(Teacher Teacher, CancellationToken cancellationToken)
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            _context.Teachers.Add(Teacher);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteTeacher(int id, CancellationToken cancellationToken)
        {
            if (_context.Teachers == null)
            {
                return false;
            }
            var Teacher = await _context.Teachers.FindAsync(id);
            if (Teacher == null)
            {
                return true;
            }

            _context.Teachers.Remove(Teacher);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        private bool TeacherExists(int id)
        {
            return (_context.Teachers?.Any(e => e.TeacherId == id)).GetValueOrDefault();
        }


    }
}
