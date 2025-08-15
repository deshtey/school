using Microsoft.EntityFrameworkCore;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class AcademicRepository : IAcademicRepository
    {
        private readonly SchoolDbContext _context;
        public AcademicRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<AcademicYear> CreateAcademicYearWithTerms(AcademicYear academicYear, CancellationToken cancellationToken = default)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.AcademicYears.AddAsync(academicYear, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
                return academicYear;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
            //await _context.AcademicYears.AddAsync(academicYear, cancellationToken);
            //await _context.SaveChangesAsync(cancellationToken);
            //foreach (var term in academicYear.Terms)
            //{
            //    term.AcademicYearId = academicYear.Id;
            //    await _context.AcademicTerms.AddAsync(term, cancellationToken);
            //}
            //await _context.SaveChangesAsync(cancellationToken);
            //return academicYear;
        }
        public async Task<AcademicYear?> GetAcademicYearByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.AcademicYears.Include(a => a.Terms).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ClassRoom?> GetClassroomByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ClassRooms.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }

        public async Task<Grade?> GetGradeByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Grades.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}
