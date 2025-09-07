using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Enums;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolDbContext _context;
        public GradeRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<Grade> CreateAsync(Grade grade, CancellationToken cancellationToken)
        {
            await _context.Grades.AddAsync(grade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return grade;
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _context.Update(new Grade { Id = id, Status = EntityStatus.Deleted });
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }

        public async Task<Grade> GetByIdAsync(int id, int schoolId, CancellationToken cancellationToken)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(g => g.Id == id && g.SchoolId == schoolId, cancellationToken);
            return grade;
        }

        public async Task<IQueryable<Grade>> GetGradesAsync(int schoolId, CancellationToken cancellationToken)
        {
            return _context.Grades.Where(g => g.Status == EntityStatus.Active && g.SchoolId == schoolId).AsQueryable();
        }

        public Task<Result<Grade>> UpdateAsync(Grade updatedGrade)
        {
            _context.Update(updatedGrade);
            _context.SaveChanges();
            return Task.FromResult(Result<Grade>.Success(updatedGrade));
        }
    }
}