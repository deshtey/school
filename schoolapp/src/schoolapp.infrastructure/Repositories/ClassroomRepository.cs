using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Enums;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolDbContext _context;
        public ClassroomRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<ClassRoom> CreateAsync(ClassRoom classroom, CancellationToken cancellationToken)
        {
            await _context.ClassRooms.AddAsync(classroom, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return classroom;
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _context.Update(new ClassRoom { Id = id, Status = EntityStatus.Deleted });
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }

        public async Task<ClassRoom> GetByIdAsync(int id, int schoolId, CancellationToken cancellationToken)
        {
            var classroom = await _context.ClassRooms.Include(c => c.Grade).FirstOrDefaultAsync(c => c.Id == id && c.Grade.SchoolId == schoolId, cancellationToken);
            return classroom;
        }

        public IQueryable<ClassRoom> GetClassroomsAsync(int schoolId, CancellationToken cancellationToken)
        {
            return _context.ClassRooms.Include(c => c.Grade).Where(c => c.Status == EntityStatus.Active && c.Grade.SchoolId == schoolId).AsQueryable();
        }

        public Task<Result<ClassRoom>> UpdateAsync(ClassRoom updatedClassroom)
        {
            _context.Update(updatedClassroom);
            _context.SaveChanges();
            return Task.FromResult(Result<ClassRoom>.Success(updatedClassroom));
        }
    }
}