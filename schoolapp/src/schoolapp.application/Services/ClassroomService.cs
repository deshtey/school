using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly ILogger<ClassroomService> _logger;
        public ClassroomService(ILogger<ClassroomService> logger, IClassroomRepository classroomRepository)
        {
            _logger = logger;
            _classroomRepository = classroomRepository;
        }

        public async Task<bool> DeleteClassRoom(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _classroomRepository.DeleteAsync(id, cancellationToken);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Deleted classroom with ID: {Id}", id);
                    return true;
                }
                _logger.LogError("Failed to delete classroom with ID: {Id}", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting classroom");
                return false;
            }
        }

        public async Task<ClassRoom?> GetClassRoom(int id, int schoolId)
        {
            try
            {
                var classroom = await _classroomRepository.GetByIdAsync(id, schoolId, CancellationToken.None);
                return classroom;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching classroom");
                return null;
            }
        }

        public async Task<IEnumerable<ClassRoom>?> GetClassRooms(int schoolId)
        {
            try
            {
                var classroomsQuery = _classroomRepository.GetClassroomsAsync(schoolId, CancellationToken.None);
                var classrooms = await classroomsQuery.ToListAsync();
                return classrooms;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching classrooms");
                return null;
            }
        }

        public async Task<bool?> PostClassRoom(ClassRoom ClassRoom, CancellationToken cancellationToken)
        {
            try
            {
                var created = await _classroomRepository.CreateAsync(ClassRoom, cancellationToken);
                _logger.LogInformation("Created classroom with ID: {Id}", created.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating classroom");
                return false;
            }
        }

        public Task<bool?> PostClassRoom(ClassRoomDto ClassRoom, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ClassRoom?> PutClassRoom(int id, ClassRoom ClassRoom, int schoolId, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _classroomRepository.GetByIdAsync(id, schoolId, cancellationToken);
                if (existing == null)
                {
                    _logger.LogWarning("Classroom with ID: {Id} not found", id);
                    return null;
                }
                ClassRoom.Id = id;
                var result = await _classroomRepository.UpdateAsync(ClassRoom);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Updated classroom with ID: {Id}", id);
                    return result.Value;
                }
                _logger.LogError("Failed to update classroom with ID: {Id}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating classroom");
                return null;
            }
        }

        public Task<ClassRoomDto?> PutClassRoom(int id, ClassRoomDto ClassRoom, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ClassRoomDto?> IClassroomService.GetClassRoom(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ClassRoomDto>?> IClassroomService.GetClassRooms(int schoolId)
        {
            throw new NotImplementedException();
        }
    }
}