using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface ISupportStaffService
    {
        Task<bool> DeleteSupportStaff(int id, CancellationToken cancellationToken);
        Task<IEnumerable<SupportStaff>?> GetSupportStaffs(int schoolId);
        Task<SupportStaff> GetSupportStaff(int id);
        Task<bool> PostSupportStaff(List<SupportStaff> SupportStaff, CancellationToken cancellationToken);
        Task<bool?> PostSupportStaff(SupportStaff SupportStaff, CancellationToken cancellationToken);
        Task<SupportStaff?> PutSupportStaff(int id, SupportStaff SupportStaff, CancellationToken cancellationToken);
    }
}