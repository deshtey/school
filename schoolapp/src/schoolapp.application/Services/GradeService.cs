using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ILogger<GradeService> _logger;
        public GradeService(ILogger<GradeService> logger, IGradeRepository gradeRepository)
        {
            _logger = logger;
            _gradeRepository = gradeRepository;
        }

        public async Task<bool> DeleteGrade(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _gradeRepository.DeleteAsync(id, cancellationToken);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Deleted grade with ID: {Id}", id);
                    return true;
                }
                _logger.LogError("Failed to delete grade with ID: {Id}", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting grade");
                return false;
            }
        }

        public async Task<Grade?> GetGrade(int id)
        {
            try
            {
                var grade = await _gradeRepository.GetByIdAsync(id, CancellationToken.None);
                return grade;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching grade");
                return null;
            }
        }

        public async Task<IEnumerable<Grade>?> GetGrades()
        {
            try
            {
                var gradesQuery = await _gradeRepository.GetGradesAsync(CancellationToken.None);
                var grades = await gradesQuery.ToListAsync();
                return grades;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching grades");
                return null;
            }
        }

        public async Task<bool?> PostGrade(Grade Grade, CancellationToken cancellationToken)
        {
            try
            {
                var created = await _gradeRepository.CreateAsync(Grade, cancellationToken);
                _logger.LogInformation("Created grade with ID: {Id}", created.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating grade");
                return false;
            }
        }

        public Task<bool?> PostGrade(GradeDto Grade, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Grade?> PutGrade(int id, Grade Grade, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _gradeRepository.GetByIdAsync(id, cancellationToken);
                if (existing == null)
                {
                    _logger.LogWarning("Grade with ID: {Id} not found", id);
                    return null;
                }
                Grade.Id = id;
                var result = await _gradeRepository.UpdateAsync(Grade);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Updated grade with ID: {Id}", id);
                    return result.Value;
                }
                _logger.LogError("Failed to update grade with ID: {Id}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating grade");
                return null;
            }
        }

        public Task<GradeDto?> PutGrade(int id, GradeDto Grade, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<GradeDto?> IGradeService.GetGrade(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<GradeDto>?> IGradeService.GetGrades()
        {
            throw new NotImplementedException();
        }
    }
}