using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolapp.Infrastructure.Repositories
{
    public class AcademicRepository : IAcademicRepository
    {
        public Task<AcademicYear?> GetAcademicYearByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Grade?> GetClassroomByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Grade?> GetGradeByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
