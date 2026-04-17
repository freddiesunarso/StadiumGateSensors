using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class GateAccessConfiguration : IEntityTypeConfiguration<GateAccess>
    {
        public void Configure(EntityTypeBuilder<GateAccess> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
