using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface ISupportStaffService
    {
        Task<bool> DeleteSupportStaff(int id, CancellationToken cancellationToken);
        Task<SupportStaffDto?> GetSupportStaff(int id);
        Task<IEnumerable<SupportStaffDto>?> GetSupportStaffs(int schoolId);
        Task<bool?> PostSupportStaff(SupportStaffDto SupportStaff, CancellationToken cancellationToken);
        Task<SupportStaff?> PutSupportStaff(int id, SupportStaffDto SupportStaff, CancellationToken cancellationToken);
    }
}