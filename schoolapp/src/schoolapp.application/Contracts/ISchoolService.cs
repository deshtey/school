using schoolapp.Application.Common.Models;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities;

namespace schoolapp.Application.Contracts
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>?> GetSchools();
        Task<School?> GetSchool(int id);
        Task<School?> PutSchool(int id, SchoolDto School, CancellationToken cancellationToken);
        Task<bool?> PostSchool(SchoolDto _school, CancellationToken cancellationToken);
        Task<bool> DeleteSchool(int id, CancellationToken cancellationToken);
        Task<Result<School>> CreateSchool(SchoolDto request, CancellationToken cancellationToken);
    }
}
