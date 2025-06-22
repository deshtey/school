using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDbContext _context;
        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<School> CreateAsync(School school, CancellationToken cancellationToken)
        {
            await _context.Schools.AddAsync(school, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return school;
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _context.Update(new School { Id = id, Status = Domain.Enums.EntityStatus.Deleted });
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }

        public async Task<School> GetByIdAsync(int schoolId, CancellationToken cancellationToken)
        {
            var school =  await _context.Schools.FirstOrDefaultAsync(s => s.Id == schoolId, cancellationToken);
            return school;
        }

        public async Task<School> GetByNameAsync(string schoolName, CancellationToken cancellationToken)
        {
            return await _context.Schools.FirstOrDefaultAsync(s => s.SchoolName == schoolName, cancellationToken);           
        }

        public async Task<IQueryable<School>> GetSchoolsAsync(CancellationToken cancellationToken)
        {
            return  _context.Schools.Where(s => s.Status == Domain.Enums.EntityStatus.Active).AsQueryable();
        }

        public Task<Result<School>> UpdateAsync(School updatedSchool)
        {
            _context.Update(updatedSchool);
            _context.SaveChanges();
            return Task.FromResult(Result<School>.Success(updatedSchool));
        }
    }
}
