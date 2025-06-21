using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>?> GetParents(int schoolId);
        Task<Parent?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Parent?> GetByNationalIdAsync(string nationalId, int schoolId, CancellationToken cancellationToken = default);
        Task<Parent?> GetByEmailAsync(string email, int schoolId, CancellationToken cancellationToken = default); Task<Parent?> PutParent(int id, Parent Parent, CancellationToken cancellationToken);
        Task<bool?> PostParent(Parent Parent, CancellationToken cancellationToken);
        Task<bool> DeleteParent(int id, CancellationToken cancellationToken);
        Task <bool> PostParents(List<ParentDto> parents, CancellationToken cancellationToken);
        Task<bool> PutParents(List<ParentDto> parents, CancellationToken cancellationToken);
    }
}
