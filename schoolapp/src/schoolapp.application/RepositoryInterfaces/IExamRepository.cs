using schoolapp.Application.Common.Models;
using schoolapp.Domain.Entities.Exams;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IExamRepository
    {
        Task<Exam> CreateAsync(Exam exam, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Exam> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IQueryable<Exam>> GetExamsAsync(int school_id, CancellationToken cancellationToken );
        Task<Result<Exam>> UpdateAsync(Exam updatedExam);
    }
}