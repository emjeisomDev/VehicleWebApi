using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Truck");

            builder.Property(t => t.LoadCapacityInTons)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.HasOne(t => t.BodyType)
                .WithMany()
                .HasForeignKey(t => t.BodyTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
