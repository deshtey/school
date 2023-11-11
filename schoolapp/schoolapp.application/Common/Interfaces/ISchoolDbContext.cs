using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolapp.Application.Common.Interfaces
{
    public interface ISchoolDbContext
    {
        DbSet<School> Schools { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
