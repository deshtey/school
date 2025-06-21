using Microsoft.EntityFrameworkCore;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.People;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly SchoolDbContext _context;

        public ParentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Parent?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Parents.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Parent?> GetByNationalIdAsync(string nationalId, int schoolId, CancellationToken cancellationToken = default)
        {
            return await _context.Parents
                .FirstOrDefaultAsync(p => p.NationalId == nationalId && p.SchoolId == schoolId, cancellationToken);
        }

        public async Task<Parent?> GetByEmailAsync(string email, int schoolId, CancellationToken cancellationToken = default)
        {
            return await _context.Parents
                .FirstOrDefaultAsync(p => p.Email == email && p.SchoolId == schoolId, cancellationToken);
        }

        public async Task AddAsync(Parent parent, CancellationToken cancellationToken = default)
        {
            await _context.Parents.AddAsync(parent, cancellationToken);
        }

        public async Task<List<Parent>> GetByIdsAsync(List<int> ids, CancellationToken cancellationToken = default)
        {
            return await _context.Parents
                .Where(p => ids.Contains(p.Id))
                .ToListAsync(cancellationToken);
        }

        public Task<Parent?> GetByPhoneAsync(string phone, int schoolId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
