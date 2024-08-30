using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Application.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>?> GetDepartments(int schoolId);
        Task<Department?> GetDepartment(int id);
        Task<Department?> PutDepartment(int id, Department Department, CancellationToken cancellationToken);
        Task<bool?> PostDepartment(Department Department, CancellationToken cancellationToken);
        Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken);
    }
}
