﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Services
{
    public class GradeClassRoomService : IGradeClassRoomService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<GradeClassRoomService> _logger;
        public GradeClassRoomService(ISchoolDbContext context, ILogger<GradeClassRoomService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<GradeDto>?> GetSchoolClasses(int schoolId)
        {
            if (_context.Grades == null)
            {
                return null;
            }
            return await _context.Grades
                .Include(g => g.ClassRooms)
                .Where(s => s.SchoolId == schoolId)
                .Select(g => new GradeDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Desc = g.Desc,
                    SchoolId = g.SchoolId,
                    Classrooms = g.ClassRooms.Select(c => new ClassRoomDto { ClassRoomId = c.Id, ClassroomName = c.Name }).ToList(),
                })
                .ToListAsync();
        }

        public async Task<GradeDto?> GetGrade(int id)
        {
            if (_context.Grades == null)
            {
                return null;
            }
            var Grade = await _context.Grades
                .Select(g => new GradeDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Desc = g.Desc,
                    SchoolId = g.SchoolId,
                    Classrooms = g.ClassRooms.Select(c => new ClassRoomDto { GradeId=c.Grade.Id, ClassRoomId = c.Id, ClassroomName = c.Name}).ToList(),

                }).FirstOrDefaultAsync(g => g.Id == id);

            if (Grade == null)
            {
                return null;
            }
            return Grade;
        }
        public async Task<ClassRoomDto?> GetClassRoom(int id)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }
            var classroom  = await _context.ClassRooms
          
                .Select(g => new ClassRoomDto
                {
                    ClassRoomId = g.Id,
                    ClassroomName = g.Name,
                    GradeId = g.Grade.Id,
                    ClassTeacherName = g.ClassTeacher != null ? g.ClassTeacher.FullName : "No teacher assigned",
                    Students = g.Students.Select(s => new StudentDto
                    {
                        Id  = s.Id,
                        Status = s.Status.ToString(),
                        Gender = s.Gender,
                        RegNumber = s.RegNumber,                        
                        ImageUrl = s.Image,
                        FullName = s.FullName,
                    }).ToList()

                }).AsNoTracking()
                .FirstOrDefaultAsync(g => g.ClassRoomId == id);

            return classroom ?? null;
        }
        public async Task<List<ClassRoomDto>?> GetSchoolClassRooms(int SchoolId)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }
            try
            {
                var classRooms = await _context.ClassRooms
                    .Where(c => c.Grade.SchoolId == SchoolId)
                    .Select(c => new ClassRoomDto
                    {
                        ClassRoomId = c.Id,
                        ClassroomName = c.Name,
                        GradeId = c.Grade.Id,
                    })
                    .ToListAsync();
                return classRooms;
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting class rooms");
                return null;
            }
        }
        public async Task<List<ClassRoomDto>?> GetGradeClassRooms(int GradeId)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }
            var classRooms = await _context.ClassRooms.Select(c => new ClassRoomDto { ClassRoomId = c.Id, ClassroomName = c.Name, GradeId = c.Grade.Id }).Where(c=>c.GradeId == GradeId).ToListAsync();      
            return classRooms;
        }
        public async Task<GradeDto?> PutGrade(int id, GradeDto grade, CancellationToken cancellationToken)
        {
            if (grade== null || id != grade.Id)
            {
                return null;
            }

            try
            {
                var existingGrade = await _context.Grades.FindAsync(new object[] { id }, cancellationToken);

                if (existingGrade == null)
                {
                    return null; // Grade with the given ID not found.
                }

                _context.Grades.Entry(existingGrade).CurrentValues.SetValues(grade);

                await _context.SaveChangesAsync(cancellationToken);

                return grade;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostGrade(GradeDto grade, CancellationToken cancellationToken)
        {
            if (_context.Grades == null)
            {
                return null;
            }
            var newGrade = new Grade
            {
                Name = grade.Name,
                Desc = grade.Desc,
                SchoolId = grade.SchoolId,
            };
            _context.Grades.Add(newGrade);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool?> PostClassroom(ClassRoomDto  classRoom, CancellationToken cancellationToken)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }
            var newclassroom = new ClassRoom
            {
                Name = classRoom.ClassroomName,
                GradeId = classRoom.GradeId,
            };
            _context.ClassRooms.Add(newclassroom);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        public async Task<ClassRoomDto?> PutClassroom(int id, ClassRoomDto classRoom, CancellationToken cancellationToken)
        {
            if (_context.ClassRooms == null)
            {
                return null;
            }

            try
            {
                var existingClassRoom = await _context.ClassRooms.FindAsync(new object[] { id }, cancellationToken);

                if (existingClassRoom == null)
                {
                    return null; // Grade with the given ID not found.
                }

                _context.ClassRooms.Entry(existingClassRoom).CurrentValues.SetValues(classRoom);

                await _context.SaveChangesAsync(cancellationToken);

                return classRoom;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }

        }
        public async Task<bool> DeleteGrade(int id, CancellationToken cancellationToken)
        {
            if (_context.Grades == null)
            {
                return false;
            }
            var Grade = await _context.Grades.FindAsync(id);
            if (Grade == null)
            {
                return true;
            }

            _context.Grades.Remove(Grade);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        public async Task<bool> DeleteClassroom(int id, CancellationToken cancellationToken)
        {
            if (_context.ClassRooms == null)
            {
                return false;
            }
            var classroom = await _context.ClassRooms.FindAsync(id);
            if (classroom == null)
            {
                return true;
            }

            _context.ClassRooms.Remove(classroom);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
