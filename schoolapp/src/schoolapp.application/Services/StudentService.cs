﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<StudentService> _logger;
        public StudentService(ISchoolDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<StudentDto>?> GetStudents(int schoolId)
        {
            try
            {
                var students = await _context.Students
               .Where(s => s.SchoolId == schoolId)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Status = s.Status.ToString(),
                    FullName = s.GetFullName(),
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    OtherName = s.OtherNames,
                    DOB = s.DOB,
                    Email = s.Email,
                    Gender = s.Gender,
                    Phone = s.Phone,
                    RegNumber = s.RegNumber
                })
               //.Select(s => new StudentParentDto
               //{
               //    Id = s.Id,
               //    SchoolId = s.SchoolId,
               //    StudentDto = new StudentDto
               //    {
               //        Status = s.Status,
               //        FullName = s.GetFullName(),
               //        FirstName = s.FirstName,
               //        LastName = s.LastName,
               //        OtherName= s.OtherNames,
               //        DOB = s.DOB,
               //        Email = s.Email,
               //        Gender = s.Gender,
               //        Phone = s.Phone,
               //        RegNumber = s.RegNumber
               //    },
               //    ParentsDto = s.Parents.Select(p => new ParentDto
               //    {
               //        Id = p.Id,
               //        FullName = p.GetFullName(),
               //        FirstName = s.FirstName,
               //        LastName = s.LastName,
               //        OtherName = s.OtherNames,
               //        Email = p.Email,
               //        Phone = p.Phone,
               //    }).ToList()

               //})
               .ToListAsync();
                return students;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching students");
                throw;
            }
        }

        public async Task<StudentParentDto?> GetStudent(int id, int schoolId)
        {

            var student = await _context.Students
                .Where(s => s.Id == id && s.SchoolId == schoolId)
                .Select(s => new StudentParentDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    StudentDto = new StudentDto
                    {
                        Status = s.Status.ToString(),
                        FullName = s.GetFullName(),
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        OtherName = s.OtherNames,
                        DOB = s.DOB,
                        ClassroomId = s.ClassRoomId,
                        Email = s.Email,
                        Gender = s.Gender,
                        Phone = s.Phone,
                        RegNumber = s.RegNumber ,
                        StudentClass=s.ClassRoom.Name
                    },
                    ParentsDto = s.Parents.Select(p => new ParentDto
                    {
                        Id = p.Id,
                        FullName = s.GetFullName(),
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        OtherName = s.OtherNames,
                        Email = p.Email,
                        Phone = p.Phone,
                    }).ToList()
                }).FirstOrDefaultAsync();

            return student?? null;
        }

        public async Task<Student?> PostStudent(StudentParentDto studentparentDto, CancellationToken cancellationToken)
        {
            if (_context.Students == null)
            {
                return null;
            }
            int schoolId = studentparentDto.SchoolId;
            Student _student = new()
            {
                SchoolId = schoolId,
                FirstName = studentparentDto.StudentDto.FirstName,
                LastName = studentparentDto.StudentDto.LastName,
                OtherNames = studentparentDto.StudentDto.OtherName,
                Email = studentparentDto.StudentDto.Email,
                ClassRoomId = studentparentDto.StudentDto.ClassroomId??null,
                Gender = studentparentDto.StudentDto.Gender,
                RegNumber = studentparentDto.StudentDto.RegNumber,
                Image = studentparentDto.StudentDto.ImageUrl
            };

            //using var transaction = _context.BeginTransactionAsync();
           

            _context.Students.Add(_student);
            await _context.SaveChangesAsync(cancellationToken);
            foreach(var _parent in studentparentDto.ParentsDto)
            {
                Parent parent = await _context.Parents.FirstOrDefaultAsync(p => p.Email == _parent.Email, cancellationToken);
                if (parent == null)
                {
                    parent = new Parent
                    {
                        Email = _parent.Email,
                        Gender = _parent.Gender,
                        Phone = _parent.Phone,
                        FirstName = _parent.FirstName,
                        LastName = _parent.LastName,
                        OtherNames = _parent.OtherName,
                        SchoolId = schoolId,
                    };
                    _context.Parents.Add(parent);
                    await _context.SaveChangesAsync(cancellationToken);
                    // Insert the relationship in the StudentParents table

                }
                var studentParent = new StudentParent
                {
                    StudentId = _student.Id,
                    ParentId = parent.Id
                };
                _context.StudentParents.Add(studentParent);
                await _context.SaveChangesAsync(cancellationToken);
            }
         
            return _student;
        }

        public async Task<Student?> PutStudent(int id, StudentParentDto student, CancellationToken cancellationToken)
        {
            if (student == null || id != student.Id)
            {
                return null;
            }

            try
            {
                var existingStudent = await _context.Students.FindAsync(new object[] { id }, cancellationToken);

                if (existingStudent == null)
                {
                    return null; // Student with the given ID not found.
                }

                _context.Students.Entry(existingStudent).CurrentValues.SetValues(student);

                await _context.SaveChangesAsync(cancellationToken);

                return existingStudent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student");
                return null;
            }
        }

        public async Task<bool> DeleteStudent(int id, CancellationToken cancellationToken)
        {
            if (_context.Students == null)
            {
                return false;
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return true;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        //public bool PromoteToNextGrade(SchoolContext context, AcademicYear currentYear, AcademicYear nextYear)
        //{
        //    if (!IsEligibleForPromotion(currentYear))
        //        return false;

        //    Grade nextGrade = CurrentGrade.GetNextGrade(context);
        //    if (nextGrade == null)
        //        return false;

        //    // Create academic record for the completed grade
        //    AcademicHistory.Add(new AcademicRecord
        //    {
        //        Student = this,
        //        Grade = CurrentGrade,
        //        ClassRoom = ClassRoom,
        //        AcademicYear = currentYear,
        //        OverallGrade = CalculateOverallGrade(currentYear),
        //        CompletionDate = currentYear.EndDate
        //    });

        //    // Update student's current grade
        //    CurrentGrade = nextGrade;

        //    // Remove from current classroom
        //    if (ClassRoom != null)
        //    {
        //        ClassRoom.RemoveStudent(this);
        //    }

        //    // Student needs to be assigned to a new classroom in the next grade
        //    // This will be handled by the school administration separately

        //    // Enroll student in all compulsory subjects for the new grade
        //    foreach (var subject in nextGrade.CompulsorySubjects)
        //    {
        //        EnrollInSubject(subject, nextYear);
        //    }

        //    return true;
        //}

        Task<StudentParentDto?> IStudentService.PutStudent(int id, StudentParentDto Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

   
    }
}
