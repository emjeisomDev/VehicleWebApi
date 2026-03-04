using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");

            builder.Property(c => c.DoorsQuantity)
                .IsRequired();

            builder.Property(c => c.TrunkLiters)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(c => c.BodyType)
                .WithMany()
                .HasForeignKey(c => c.BodyTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
