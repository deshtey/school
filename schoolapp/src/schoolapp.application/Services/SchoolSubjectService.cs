using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Services
{
    public class SchoolSubjectService : ISchoolSubjectService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<SchoolSubjectService> _logger;
        public SchoolSubjectService(ISchoolDbContext context, ILogger<SchoolSubjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<SchoolSubjectDto>?> GetSchoolSubjects(int schoolId)
        {
            if (_context.SchoolSubjects == null)
            {
                return null;
            }
            return await _context.SchoolSubjects.Where(s => s.SchoolId == schoolId)
                .Select(t => new SchoolSubjectDto
                {
                    Id = t.Id,
                    Desc = t.Desc,
                    SchoolId = t.SchoolId                    
                })
                .ToListAsync();
        }

        public async Task<SchoolSubjectDto?> GetSchoolSubject(int id)
        {
            if (_context.SchoolSubjects == null)
            {
                return null;
            }
            var SchoolSubject = await _context.SchoolSubjects.Where(t => t.Id == id)
                .Select(t => new SchoolSubjectDto
                {
                    Id = t.Id,
                    Desc= t.Desc,
                    SchoolId = t.SchoolId
                }).FirstOrDefaultAsync();

            if (SchoolSubject == null)
            {
                return null;
            }
            return SchoolSubject;
        }

        public async Task<SchoolSubject?> PutSchoolSubject(int id, SchoolSubjectDto schoolsubject, CancellationToken cancellationToken)
        {
            if (schoolsubject == null || id != schoolsubject.Id)
            {
                return null;
            }

            try
            {
                var existingSchoolSubject = await _context.SchoolSubjects.FindAsync([id], cancellationToken);

                if (existingSchoolSubject == null)
                {
                    return null; // SchoolSubject with the given ID not found.
                }

                _context.SchoolSubjects.Entry(existingSchoolSubject).CurrentValues.SetValues(schoolsubject);

                await _context.SaveChangesAsync(cancellationToken);

                return existingSchoolSubject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostSchoolSubject(SchoolSubjectDto schoolsubject, CancellationToken cancellationToken)
        {
            if (_context.SchoolSubjects == null)
            {
                return null;
            }
            SchoolSubject newSchoolSubject = new SchoolSubject
            {
                Desc = schoolsubject.Desc,
                SubjectName = schoolsubject.SubjectName,
                SchoolId = schoolsubject.SchoolId
            };
            _context.SchoolSubjects.Add(newSchoolSubject);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteSchoolSubject(int id, CancellationToken cancellationToken)
        {
            if (_context.SchoolSubjects == null)
            {
                return false;
            }
            var SchoolSubject = await _context.SchoolSubjects.FindAsync(id);
            if (SchoolSubject == null)
            {
                return true;
            }

            _context.SchoolSubjects.Remove(SchoolSubject);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }


    }
}
