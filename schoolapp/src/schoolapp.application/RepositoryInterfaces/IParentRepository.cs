using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IParentRepository
    {
        Task<Parent?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Parent?> GetByNationalIdAsync(string nationalId, int schoolId, CancellationToken cancellationToken = default);
        Task<Parent?> GetByPhoneAsync(string phone, int schoolId, CancellationToken cancellationToken = default);
        Task<Parent?> GetByEmailAsync(string email, int schoolId, CancellationToken cancellationToken = default);
        Task AddAsync(Parent parent, CancellationToken cancellationToken = default);
        Task<List<Parent>> GetByIdsAsync(List<int> ids, CancellationToken cancellationToken = default);
    }

}
