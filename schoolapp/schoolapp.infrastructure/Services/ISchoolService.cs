using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;

namespace schoolapp.Infrastructure.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>?> GetSchools();
        Task<School?> GetSchool(int id);
        Task<School?> PutSchool(int id, School School);
        Task<bool?> PostSchool(School School);
        Task<bool> DeleteSchool(int id);
    }
}