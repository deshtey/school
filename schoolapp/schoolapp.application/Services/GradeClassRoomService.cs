using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Services
{
    public class GradeClassRoomService : IGradeClassRoomService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<GradeClassRoomService> _logger;
        public GradeClassRoomService(ISchoolDbContext context, ILogger<GradeClassRoomService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Grade>?> GetSchoolClasses(int schoolId)
        {
            if (_context.Grades == null)
            {
                return null;
            }
            return await _context.Grades.Where(s => s.SchoolId == schoolId).ToListAsync();
        }

        public async Task<Grade?> GetGrade(int id)
        {
            if (_context.Grades == null)
            {
                return null;
            }
            var Grade = await _context.Grades.FindAsync(id);

            if (Grade == null)
            {
                return null;
            }
            return Grade;
        }
        public async Task<List<ClassRoom>?> GetSchoolClassRooms(int SchoolId)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }
            var classRooms = await _context.ClassRooms.Where(c => c.SchoolId == SchoolId).ToListAsync();
            return classRooms;
        }
        public async Task<List<ClassRoom>?> GetGradeClassRooms(int GradeId)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }
            var classRooms = await _context.ClassRooms.Where(c=>c.GradeId == GradeId).ToListAsync();      
            return classRooms;
        }
        public async Task<Grade?> PutGrade(int id, Grade grade, CancellationToken cancellationToken)
        {
            if (grade== null || id != grade.Id)
            {
                return null;
            }

            try
            {
                var existingGrade = await _context.Grades.FindAsync(new object[] { id }, cancellationToken);

                if (existingGrade == null)
                {
                    return null; // Grade with the given ID not found.
                }

                _context.Grades.Entry(existingGrade).CurrentValues.SetValues(grade);

                await _context.SaveChangesAsync(cancellationToken);

                return existingGrade;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostGrade(Grade Grade, CancellationToken cancellationToken)
        {
            if (_context.Grades == null)
            {
                return null;
            }
            _context.Grades.Add(Grade);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteGrade(int id, CancellationToken cancellationToken)
        {
            if (_context.Grades == null)
            {
                return false;
            }
            var Grade = await _context.Grades.FindAsync(id);
            if (Grade == null)
            {
                return true;
            }

            _context.Grades.Remove(Grade);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
     }
}
