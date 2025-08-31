using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Contracts;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.Exams;

namespace schoolapp.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogger<ExamService> _logger;
        public ExamService(ILogger<ExamService> logger, IExamRepository examRepository)
        {
            _logger = logger;
            _examRepository = examRepository;
        }

        public async Task<bool> DeleteExam(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _examRepository.DeleteAsync(id, cancellationToken);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Deleted exam with ID: {Id}", id);
                    return true;
                }
                _logger.LogError("Failed to delete exam with ID: {Id}", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting exam");
                return false;
            }
        }

        public async Task<Exam?> GetExam(int id)
        {
            try
            {
                var exam = await _examRepository.GetByIdAsync(id, CancellationToken.None);
                return exam;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching exam");
                return null;
            }
        }

        public async Task<IEnumerable<Exam>?> GetExams()
        {
            try
            {
                var examsQuery = await _examRepository.GetExamsAsync(CancellationToken.None);
                var exams = await examsQuery.ToListAsync();
                return exams;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching exams");
                return null;
            }
        }

        public async Task<bool?> PostExam(Exam Exam, CancellationToken cancellationToken)
        {
            try
            {
                var created = await _examRepository.CreateAsync(Exam, cancellationToken);
                _logger.LogInformation("Created exam with ID: {Id}", created.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating exam");
                return false;
            }
        }

        public async Task<Exam?> PutExam(int id, Exam Exam, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _examRepository.GetByIdAsync(id, cancellationToken);
                if (existing == null)
                {
                    _logger.LogWarning("Exam with ID: {Id} not found", id);
                    return null;
                }
                Exam.Id = id;
                var result = await _examRepository.UpdateAsync(Exam);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Updated exam with ID: {Id}", id);
                    return result.Value;
                }
                _logger.LogError("Failed to update exam with ID: {Id}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating exam");
                return null;
            }
        }
    }
}