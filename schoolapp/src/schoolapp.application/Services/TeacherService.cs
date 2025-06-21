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
                    Id = t.Id,
                    FullName = t.FullName,
                    Salutation = t.Salutation,
                    ImageUrl = t.Image,
                    Email = t.Email,
                    Gender = t.Gender,
                    Phone   = t.Phone,
                    SchoolId    = t.SchoolId,
                    Status  = t.Status.ToString(),
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
            var teacher = await _context.Teachers.Where(t=>t.Id==id)
                .Include(t => t.Departments)
                .Select(t => new TeacherDto
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    OtherName = t.OtherNames,
                    DOB = t.DateOfBirth,
                    ImageUrl = t.Image,
                    Salutation  = t.Salutation,
                    Email = t.Email,
                    Gender = t.Gender,
                    Phone = t.Phone,
                    SchoolId = t.SchoolId,
                    Status = t.Status.ToString(),
                    RegNo = t.RegNo,
                    Departments = t.Departments.Select(d => new DepartmentDto { Id = d.Id, DepartmentName = d.DepartmentName }).ToList(),
                    //ClassRooms = t.ClassRooms.Select(c => new ClassRoomDto { ClassRoomId = c.ClassRoomId, ClassroomName = c.ClassroomName }).ToList(),

                })
                .FirstOrDefaultAsync();

        
            return teacher;
        }

        public async Task<Teacher?> PutTeacher(int id, TeacherDto teacher, CancellationToken cancellationToken)
        {
            if (teacher == null || id != teacher.Id)
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

        public async Task<bool?> PostTeacher(TeacherDto teacherDto, CancellationToken cancellationToken)
        {
            if (_context.Teachers == null)
            {
                return null;
            }
            var newTeacher = new Teacher(teacherDto.FirstName, teacherDto.LastName, teacherDto.SchoolId, teacherDto.Gender.Value);
            newTeacher.OtherNames = teacherDto.OtherName;
            newTeacher.Salutation = teacherDto.Salutation;
            newTeacher.DateOfBirth = teacherDto.DOB;
            newTeacher.Email = teacherDto.Email;
            newTeacher.RegNo = teacherDto.RegNo;
            newTeacher.Image = teacherDto.ImageUrl;
            newTeacher.Phone = teacherDto.Phone;  

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
