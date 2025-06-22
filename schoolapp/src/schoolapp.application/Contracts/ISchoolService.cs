using schoolapp.Application.Common.Models;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities;

namespace schoolapp.Application.Contracts
{
    public interface ISchoolService
    {
        Task<Result<bool>> DeleteSchool(int id, CancellationToken cancellationToken);
        Task<Result<SchoolDto>> GetSchool(int schoolId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<SchoolDto>>> GetSchools(CancellationToken cancellationToken);
        Task<Result<School>> PostSchool(SchoolDto _school, CancellationToken cancellationToken);
        Task<Result<SchoolDto>> PutSchool(int id, SchoolDto request, CancellationToken cancellationToken);
    }
}
