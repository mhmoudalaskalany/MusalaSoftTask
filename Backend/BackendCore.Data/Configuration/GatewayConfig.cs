using BackendCore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCore.Data.Configuration
{
    public class GatewayConfig : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasIndex(e => e.SerialNumber).IsUnique();
            builder.Property(a => a.SerialNumber).HasMaxLength(255);
            builder.Property(a => a.Name).HasMaxLength(255);
            builder.Property(a => a.Name).HasMaxLength(255);
        }
    }
}