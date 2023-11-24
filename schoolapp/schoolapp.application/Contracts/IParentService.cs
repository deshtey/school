using schoolapp.Domain.Entities.People;

namespace Parentapp.Application.Contracts
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>?> GetParents();
        Task<Parent?> GetParent(int id);
        Task<Parent?> PutParent(int id, Parent Parent, CancellationToken cancellationToken);
        Task<bool?> PostParent(Parent Parent, CancellationToken cancellationToken);
        Task<bool> DeleteParent(int id, CancellationToken cancellationToken);
    }
}
