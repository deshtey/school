using Parentapp.Application.Contracts;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class ParentService : IParentService
    {
        private readonly ISchoolDbContext _context;

        public ParentService()
        {
            
        }
        public Task<bool> DeleteParent(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Parent?> GetParent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Parent>?> GetParents()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> PostParent(Parent Parent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Parent?> PutParent(int id, Parent Parent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
