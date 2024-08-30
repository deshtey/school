using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<TeacherService> _logger;
        public TeacherService(ISchoolDbContext context, ILogger<TeacherService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<TeacherDto>?> GetTeachers(int schoolId)
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            return await _context.Teachers.Where(s => s.SchoolId == schoolId)
                .Include(t=>t.Departments)
                .Select(t=>new TeacherDto
                {
                    Name = t.Name,
                    Email = t.Email,
                    Gender = t.Gender,
                    Phone   = t.Phone,
                    SchoolId    = t.SchoolId,
                    Status  = t.Status,
                    TeacherId   = t.TeacherId,
                    RegNo = t.RegNo,
                   // Departments = t.Departments.Select(d=>new DepartmentDto{Id=d.Id,DepartmentName=d.DepartmentName}).ToList(),
                   // ClassRooms = t.ClassRooms.Select(c=>new ClassRoomDto{ClassRoomId=c.ClassRoomId,ClassroomName=c.ClassroomName}).ToList(),
                       
                })
                .ToListAsync();
        }

        public async Task<TeacherDto?> GetTeacher(int id)
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            var teacher = await _context.Teachers.Where(t=>t.TeacherId==id)
                .Include(t => t.Departments)
                .Select(t => new TeacherDto
                {
                    Name = t.Name,
                    Email = t.Email,
                    Gender = t.Gender,
                    Phone = t.Phone,
                    SchoolId = t.SchoolId,
                    Status = t.Status,
                    TeacherId = t.TeacherId,
                    RegNo = t.RegNo,
                    Departments = t.Departments.Select(d => new DepartmentDto { Id = d.Id, DepartmentName = d.DepartmentName }).ToList(),
                    ClassRooms = t.ClassRooms.Select(c => new ClassRoomDto { ClassRoomId = c.ClassRoomId, ClassroomName = c.ClassroomName }).ToList(),

                })
                .FirstOrDefaultAsync();

        
            return teacher;
        }

        public async Task<Teacher?> PutTeacher(int id, TeacherDto teacher, CancellationToken cancellationToken)
        {
            if (teacher == null || id != teacher.TeacherId)
            {
                return null;
            }

            try
            {
                var existingTeacher = await _context.Teachers.FindAsync([id], cancellationToken);

                if (existingTeacher == null)
                {
                    return null; // Teacher with the given ID not found.
                }

                _context.Teachers.Entry(existingTeacher).CurrentValues.SetValues(teacher);

                await _context.SaveChangesAsync(cancellationToken);

                return existingTeacher;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostTeacher(TeacherDto teacher, CancellationToken cancellationToken)
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            var newTeacher = new Teacher
            {
                SchoolId   = teacher.SchoolId,
                Name = teacher.Name,
                DOB = teacher.DOB,
                Active = true,
                Email   = teacher.Email,
                Gender = teacher.Gender,    
                RegNo = teacher.RegNo,
               Image = teacher.Image,
               Phone = teacher.Phone    

            };
            _context.Teachers.Add(newTeacher);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteTeacher(int id, CancellationToken cancellationToken)
        {
            if (_context.Teachers == null)
            {
                return false;
            }
            var Teacher = await _context.Teachers.FindAsync(id);
            if (Teacher == null)
            {
                return true;
            }

            _context.Teachers.Remove(Teacher);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
     }
}
