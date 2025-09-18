using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Exams;

namespace schoolapp.Application.Contracts
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>?> GetExams(int schoolId, CancellationToken cancellationToken);
        Task<ExamDto?> GetExam(int id, CancellationToken cancellationToken);
        Task<ExamDto?> PutExam(int id, ExamDto Exam, CancellationToken cancellationToken);
        Task<bool?> PostExam(ExamDto Exam, CancellationToken cancellationToken);
        Task<bool> DeleteExam(int id, CancellationToken cancellationToken);
    }
}
