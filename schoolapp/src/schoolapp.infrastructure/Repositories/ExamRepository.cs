using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.Exams;
using schoolapp.Domain.Enums;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly SchoolDbContext _context;
        public ExamRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<Exam> CreateAsync(Exam exam, CancellationToken cancellationToken)
        {
            await _context.Exams.AddAsync(exam, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return exam;
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _context.Update(new Exam { Id = id, Status = EntityStatus.Deleted });
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }

        public async Task<Exam> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            return exam;
        }

        public async Task<IQueryable<Exam>> GetExamsAsync(int school_id, CancellationToken cancellationToken)
        {
            return _context.Exams.Where(e=>e.SchoolId == school_id).AsQueryable();
        }

        public Task<Result<Exam>> UpdateAsync(Exam updatedExam)
        {
            _context.Update(updatedExam);
            _context.SaveChanges();
            return Task.FromResult(Result<Exam>.Success(updatedExam));
        }
    }
}