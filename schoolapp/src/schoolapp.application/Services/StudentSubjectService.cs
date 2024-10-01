using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Academics;

namespace studentapp.Application.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<StudentSubjectService> _logger;
        public StudentSubjectService(ISchoolDbContext context, ILogger<StudentSubjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<StudentSubjectDto>?> GetStudentSubjects(int studentId)
        {
            if (_context.StudentSubjects == null)
            {
                return null;
            }
            return await _context.StudentSubjects.Where(s => s.StudentId == studentId)
                .Select(t => new StudentSubjectDto
                {
                    Id = t.Id,
                    SubjectName= t.SubjectName,
                    Elective = t.Elective,
                    StudentId = t.StudentId,
                    ClassroomSubjectId = t.ClassroomSubjectId,
                    SubjectId = t.SubjectId,

                })
                .ToListAsync();
        }

        public async Task<StudentSubjectDto?> GetStudentSubject(int id)
        {
            if (_context.StudentSubjects == null)
            {
                return null;
            }
            var StudentSubject = await _context.StudentSubjects.Where(t => t.Id == id)
                .Select(t => new StudentSubjectDto
                {
                    Id = t.Id,
                    SubjectName= t.SubjectName,
                    Elective = t.Elective,
                    StudentId = t.StudentId,
                    ClassroomSubjectId= t.ClassroomSubjectId,
                    SubjectId= t.SubjectId,
                }).FirstOrDefaultAsync();

            if (StudentSubject == null)
            {
                return null;
            }
            return StudentSubject;
        }

        public async Task<StudentSubject?> PutStudentSubject(int id, StudentSubjectDto StudentSubject, CancellationToken cancellationToken)
        {
            if (StudentSubject == null || id != StudentSubject.Id)
            {
                return null;
            }

            try
            {
                var existingStudentSubject = await _context.StudentSubjects.FindAsync([id], cancellationToken);

                if (existingStudentSubject == null)
                {
                    return null; // StudentSubject with the given ID not found.
                }

                _context.StudentSubjects.Entry(existingStudentSubject).CurrentValues.SetValues(StudentSubject);

                await _context.SaveChangesAsync(cancellationToken);

                return existingStudentSubject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student");
                return null;
            }
        }

        public async Task<bool?> PostStudentSubject(StudentSubjectDto StudentSubject, CancellationToken cancellationToken)
        {
            if (_context.StudentSubjects == null)
            {
                return null;
            }
            StudentSubject newStudentSubject = new StudentSubject
            {
                Elective = StudentSubject.Elective,
                StudentId = StudentSubject.StudentId,
                SubjectName = StudentSubject.SubjectName,
                ClassroomSubjectId = StudentSubject.ClassroomSubjectId,
                
            };
            _context.StudentSubjects.Add(newStudentSubject);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteStudentSubject(int id, CancellationToken cancellationToken)
        {
            if (_context.StudentSubjects == null)
            {
                return false;
            }
            var StudentSubject = await _context.StudentSubjects.FindAsync(id);
            if (StudentSubject == null)
            {
                return true;
            }

            _context.StudentSubjects.Remove(StudentSubject);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }


    }
}
