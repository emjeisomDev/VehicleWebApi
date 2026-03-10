using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable("VehicleType");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(v => v.Name)
                .IsUnique();

            builder.HasData(
                new { Id = 1, Name = "Car" },
                new { Id = 2, Name = "Truck" },
                new { Id = 3, Name = "Motorcycle" }
            );
        }
    }
}
