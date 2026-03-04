using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(v => v.ModelVersion)
                .WithMany(mv => mv.Vehicles)
                .HasForeignKey(v => v.ModelVersionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.VehicleType)
                .WithMany()
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
