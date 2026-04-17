using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IGateAccessDbContext
{
    public DbSet<GateAccess> GateAccesses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
