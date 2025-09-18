using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Services
{
    public class ClassroomStudentService : IClassroomStudentService
    {
        private readonly IClassroomStudentRepository _classroomStudentRepository;
        private readonly ILogger<ClassroomStudentService> _logger;
        public ClassroomStudentService(ILogger<ClassroomStudentService> logger, IClassroomStudentRepository classroomStudentRepository)
        {
            _logger = logger;
            _classroomStudentRepository = classroomStudentRepository;
        }

        public async Task<bool> DeleteClassRoomStudent(int classroomId, int studentId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _classroomStudentRepository.DeleteAsync(classroomId, studentId, cancellationToken);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Deleted classroom student with classroom ID: {ClassroomId}, student ID: {StudentId}", classroomId, studentId);
                    return true;
                }
                _logger.LogError("Failed to delete classroom student with classroom ID: {ClassroomId}, student ID: {StudentId}", classroomId, studentId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting classroom student");
                return false;
            }
        }

        public async Task<ClassRoomStudent?> GetClassRoomStudent(int classroomId, int studentId)
        {
            try
            {
                var classroomStudent = await _classroomStudentRepository.GetByIdAsync(classroomId, studentId,  CancellationToken.None);
                return classroomStudent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching classroom student");
                return null;
            }
        }

        public async Task<IEnumerable<ClassRoomStudent>?> GetClassRoomStudents(int schoolId, int classroomId)
        {
            try
            {
                var classroomStudents = await _classroomStudentRepository.GetClassroomStudentsAsync(schoolId, classroomId, CancellationToken.None);               
                return classroomStudents;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching classroom students");
                return null;
            }
        }

        public Task<IEnumerable<ClassRoomStudent>?> GetClassRoomStudents()
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> PostClassRoomStudent(ClassRoomStudentDto ClassRoomStudent, CancellationToken cancellationToken)
        {
            try
            {
                var _classroomStudent = new ClassRoomStudent
                {
                    ClassRoomId = ClassRoomStudent.ClassRoomId,
                    StudentId = ClassRoomStudent.StudentId,
                };
                var created = await _classroomStudentRepository.CreateAsync(_classroomStudent, cancellationToken);
                _logger.LogInformation("Created classroom student with classroom ID: {ClassroomId}, student ID: {StudentId}", created.ClassRoomId, created.StudentId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating classroom student");
                return false;
            }
        }

        public Task<bool?> PostClassRoomStudent(ClassRoomStudent ClassRoomStudent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ClassRoomStudent?> PutClassRoomStudent(int classroomId, int studentId, ClassRoomStudentDto classRoomStudentDto, CancellationToken cancellationToken)
        {
            try
            {
     
                var existing = await _classroomStudentRepository.GetByIdAsync(classRoomStudentDto.ClassRoomId, classRoomStudentDto.StudentId,cancellationToken);
                if (existing == null)
                {
                    _logger.LogWarning("Classroom student with classroom ID: {ClassroomId}, student ID: {StudentId} not found", classroomId, studentId);
                    return null;
                }
                existing.ClassRoomId = classroomId;
                existing.StudentId = studentId;
                var result = await _classroomStudentRepository.UpdateAsync(existing);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Updated classroom student with classroom ID: {ClassroomId}, student ID: {StudentId}", classroomId, studentId);
                    return result.Value;
                }
                _logger.LogError("Failed to update classroom student with classroom ID: {ClassroomId}, student ID: {StudentId}", classroomId, studentId);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating classroom student");
                return null;
            }
        }

 
    }
}