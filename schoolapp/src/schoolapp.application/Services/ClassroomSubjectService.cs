using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Services
{
    public class ClassRoomSubjectService : IClassRoomSubjectService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<ClassRoomSubjectService> _logger;
        public ClassRoomSubjectService(ISchoolDbContext context, ILogger<ClassRoomSubjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<ClassRoomSubjectDto>?> GetClassRoomSubjects(int classroomId)
        {
            if (_context.ClassRoomSubjects == null)
            {
                return null;
            }
            return await _context.ClassRoomSubjects.Where(s => s.ClassRoomId == classroomId)
                .Select(t => new ClassRoomSubjectDto
                {
                    Id = t.Id,
                    SubjectName = t.SubjectName,
                    SchoolSubjectId = t.SchoolSubjectId,
                    ClassRoomId = t.ClassRoomId,
                    Elective  = t.Elective,

                    
                })
                .ToListAsync();
        }

        public async Task<ClassRoomSubjectDto?> GetClassRoomSubject(int id)
        {
            if (_context.ClassRoomSubjects == null)
            {
                return null;
            }
            var ClassRoomSubject = await _context.ClassRoomSubjects.Where(t => t.Id == id)
                .Select(t => new ClassRoomSubjectDto
                {
                    Id = t.Id,
                    SubjectName = t.SubjectName,
                    SchoolSubjectId = t.SchoolSubjectId,
                    ClassRoomId= t.ClassRoomId,
                    Elective= t.Elective,
                }).FirstOrDefaultAsync();

            if (ClassRoomSubject == null)
            {
                return null;
            }
            return ClassRoomSubject;
        }

        public async Task<ClassRoomSubject?> PutClassRoomSubject(int id, ClassRoomSubjectDto ClassRoomsubject, CancellationToken cancellationToken)
        {
            if (ClassRoomsubject == null || id != ClassRoomsubject.Id)
            {
                return null;
            }

            try
            {
                var existingClassRoomSubject = await _context.ClassRoomSubjects.FindAsync([id], cancellationToken);

                if (existingClassRoomSubject == null)
                {
                    return null; // ClassRoomSubject with the given ID not found.
                }

                _context.ClassRoomSubjects.Entry(existingClassRoomSubject).CurrentValues.SetValues(ClassRoomsubject);

                await _context.SaveChangesAsync(cancellationToken);

                return existingClassRoomSubject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostClassRoomSubject(ClassRoomSubjectDto ClassRoomsubject, CancellationToken cancellationToken)
        {
            if (_context.ClassRoomSubjects == null)
            {
                return null;
            }
            ClassRoomSubject newClassRoomSubject = new ClassRoomSubject
            {
                SubjectName = ClassRoomsubject.SubjectName,
                ClassRoomId = ClassRoomsubject.ClassRoomId,
                Elective = ClassRoomsubject.Elective,
                SchoolSubjectId = ClassRoomsubject.SchoolSubjectId               
                
            };
            _context.ClassRoomSubjects.Add(newClassRoomSubject);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteClassRoomSubject(int id, CancellationToken cancellationToken)
        {
            if (_context.ClassRoomSubjects == null)
            {
                return false;
            }
            var ClassRoomSubject = await _context.ClassRoomSubjects.FindAsync(id);
            if (ClassRoomSubject == null)
            {
                return true;
            }

            _context.ClassRoomSubjects.Remove(ClassRoomSubject);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }


    }
}
