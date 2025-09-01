using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Exams;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Common.Mappings
{
    public static class DtoConverters
    {
        public static SchoolDto ToSchoolDto(School school)
        {
            if (school == null) return null;

            return new SchoolDto
            {
                SchoolId = school.Id,
                SchoolName = school.SchoolName,
                Address = school.Address,
                City = school.City,
                Street = school.Street,
                PostalCode = school.PostalCode,
                Status = school.Status,
                CreatedAt = school.Created,
                Country = school.Country,
                Email = school.Email,
                HomePage = school.HomePage,
                Phone = school.Phone
            };
        }

        public static ClassRoomDto ToClassRoomDto(ClassRoom classroom)
        {
            if (classroom == null) return null;

            return new ClassRoomDto
            {
                ClassRoomId = classroom.Id,
                ClassroomName = classroom.Name,
                GradeId = classroom.GradeId,
                TeacherId = classroom.TeacherId,
                // Add other mappings as needed
            };
        }

        public static GradeDto ToGradeDto(Grade grade)
        {
            if (grade == null) return null;

            return new GradeDto
            {
                Id = grade.Id,
                Name = grade.Name,
                // Add other mappings
            };
        }

        public static SupportStaffDto ToSupportStaffDto(SupportStaff staff)
        {
            if (staff == null) return null;

            return new SupportStaffDto
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                // Add other mappings
            };
        }

        public static ExamDto ToExamDto(Exam exam)
        {
            if (exam == null) return null;

            return new ExamDto
            {
                Id = exam.Id,
                Name = exam.Description,
                // Add other mappings
            };
        }
    }
}
