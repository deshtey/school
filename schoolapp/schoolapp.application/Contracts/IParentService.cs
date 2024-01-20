using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>?> GetParents(int schoolId);
        Task<Parent?> GetParent(int id);
        Task<Parent?> PutParent(int id, Parent Parent, CancellationToken cancellationToken);
        Task<bool?> PostParent(Parent Parent, CancellationToken cancellationToken);
        Task<bool> DeleteParent(int id, CancellationToken cancellationToken);
        Task <bool> PostParents(List<Parent> parents, CancellationToken cancellationToken);
    }
}
