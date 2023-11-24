using schoolapp.Domain.Entities.Exams;

namespace Examapp.Application.Contracts
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>?> GetExams();
        Task<Exam?> GetExam(int id);
        Task<Exam?> PutExam(int id, Exam Exam, CancellationToken cancellationToken);
        Task<bool?> PostExam(Exam Exam, CancellationToken cancellationToken);
        Task<bool> DeleteExam(int id, CancellationToken cancellationToken);
    }
}
