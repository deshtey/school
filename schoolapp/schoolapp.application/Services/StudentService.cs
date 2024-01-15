using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities.People;
using Studentapp.Application.Contracts;

namespace schoolapp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ISchoolDbContext _context;

        public StudentService(ISchoolDbContext context)
        {
            _context = context;
        }
        public Task<bool> DeleteStudent(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Student?> GetStudent(int id, int schoolId)
        {
            var student =  await _context.Students.FindAsync(id);
            return student == null ? null : student;
        }

        public Task<IEnumerable<Student>?> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> PostStudent(Student Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> PutStudent(int id, Student Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
