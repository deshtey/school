using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class ParentService : IParentService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<Parent> _logger;
        public ParentService(ISchoolDbContext context, ILogger<Parent> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Parent?> GetParent(int id, int schoolId)
        {
            var parent = await _context.Parents.FindAsync(id);
            return parent == null ? null : parent;
        }

        public async Task<IEnumerable<Parent>?> GetParents(int schoolId)
        {
            var Parents = await _context.Parents.Where(s => s.SchoolId == schoolId).ToListAsync();
            return Parents;
        }

        public async Task<bool?> PostParent(Parent Parent, CancellationToken cancellationToken)
        {
            if (_context.Parents == null)
            {
                return null;
            }
            _context.Parents.Add(Parent);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Parent?> PutParent(int id, Parent parent, CancellationToken cancellationToken)
        {
            if (parent == null || id != parent.Id)
            {
                return null;
            }

            try
            {
                var existingParent = await _context.Parents.FindAsync(new object[] { id }, cancellationToken);

                if (existingParent == null)
                {
                    return null; // Parent with the given ID not found.
                }

                _context.Parents.Entry(existingParent).CurrentValues.SetValues(parent);

                await _context.SaveChangesAsync(cancellationToken);

                return existingParent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Parent");
                return null;
            }
        }
        public async Task<bool> DeleteParent(int id, CancellationToken cancellationToken)
        {
            if (_context.Parents == null)
            {
                return false;
            }
            var Parent = await _context.Parents.FindAsync(id);
            if (Parent == null)
            {
                return true;
            }

            _context.Parents.Remove(Parent);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        private bool ParentExists(int id)
        {
            return (_context.Parents?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public Task<Parent?> GetParent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostParents(List<Parent> parents, CancellationToken cancellationToken)
        {
            if (_context.Parents == null)
            {
                return false;
            }
            foreach (var parent in parents)
            {
                _context.Parents.Add(parent);
            }
           
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        public async Task<bool> PutParents(List<Parent> parents, CancellationToken cancellationToken)
        {
            foreach (var parent in parents)
            {
                if (parent == null)
                {
                    return false;
                }

                try
                {
                    var existingParent = await _context.Parents.FindAsync(new object[] { parent.Id }, cancellationToken);

                    if (existingParent == null)
                    {
                        return false; // Parent with the given ID not found.
                    }

                    _context.Parents.Entry(existingParent).CurrentValues.SetValues(parent);
               
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating Parent");
                    return false;
                }
            }
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
