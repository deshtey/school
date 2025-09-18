using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Enums;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class ClassroomStudentRepository : IClassroomStudentRepository
    {
        private readonly SchoolDbContext _context;
        public ClassroomStudentRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<ClassRoomStudent> CreateAsync(ClassRoomStudent classroomStudent, CancellationToken cancellationToken)
        {
            await _context.ClassRoomStudents.AddAsync(classroomStudent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return classroomStudent;
        }

        public async Task<Result<bool>> DeleteAsync(int classroomId, int studentId, CancellationToken cancellationToken)
        {
            var entity = await _context.ClassRoomStudents.FirstOrDefaultAsync(cs => cs.ClassRoomId == classroomId && cs.StudentId == studentId, cancellationToken);
            if (entity != null)
            {
                _context.ClassRoomStudents.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            return Result<bool>.Failure(["ClassRoomStudent not found"]);
        }

        public async Task<ClassRoomStudent> GetByIdAsync(int classroomId, int studentId, CancellationToken cancellationToken)
        {
            var classroomStudent = await _context.ClassRoomStudents.Include(cs => cs.Student).FirstOrDefaultAsync(cs => cs.ClassRoomId == classroomId && cs.StudentId == studentId , cancellationToken);
            return classroomStudent;
        }

        public async Task<ICollection<ClassRoomStudent>> GetClassroomStudentsAsync(int schoolId, int classroomId, CancellationToken cancellationToken)
        {
            var students = await _context.ClassRoomStudents
                .Include(cs => cs.Student)
                .Where(cs => cs.ClassRoomId == classroomId && cs.Student.SchoolId == schoolId && cs.Status == EntityStatus.Active).ToListAsync(cancellationToken);  
                ;
            return students;
        }

        public Task<Result<ClassRoomStudent>> UpdateAsync(ClassRoomStudent updatedClassroomStudent)
        {
            _context.Update(updatedClassroomStudent);
            _context.SaveChanges();
            return Task.FromResult(Result<ClassRoomStudent>.Success(updatedClassroomStudent));
        }
    }
}