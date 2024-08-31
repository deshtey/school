using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Application.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>?> GetDepartments(int schoolId);
        Task<DepartmentDto?> GetDepartment(int id);
        Task<bool?> PostDepartment(DepartmentDto Department, CancellationToken cancellationToken);
        Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken);
        Task<Department?> PutDepartment(int id, DepartmentDto department, CancellationToken cancellationToken);
    }
}
