using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class GateAccessDbContext(DbContextOptions<GateAccessDbContext> options) : DbContext(options), IGateAccessDbContext
    {
        public DbSet<GateAccess> GateAccesses => Set<GateAccess>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
