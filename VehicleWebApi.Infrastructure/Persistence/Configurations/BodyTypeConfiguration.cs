using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class BodyTypeConfiguration : IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.ToTable("BodyType");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.HasIndex(b => b.Name)
                .IsUnique();

            builder.HasData(
                new { Id = 1, Name = "Sedan" },
                new { Id = 2, Name = "Hatchback" },
                new { Id = 3, Name = "SUV" },
                new { Id = 4, Name = "Coupé" },
                new { Id = 5, Name = "Convertible" },
                new { Id = 6, Name = "Station Wagon" },
                new { Id = 7, Name = "Minivan" },
                new { Id = 8, Name = "Sports Car" },
                new { Id = 9, Name = "Pickup Truck" },
                new { Id = 10, Name = "Electric Vehicle" },
                new { Id = 11, Name = "Semi-Truck" },
                new { Id = 12, Name = "Dump Truck" },
                new { Id = 13, Name = "Box Truck" },
                new { Id = 14, Name = "Flatbed Truck" },
                new { Id = 15, Name = "Refrigerated Truck" },
                new { Id = 16, Name = "Tanker Truck" },
                new { Id = 17, Name = "Tow Truck" },
                new { Id = 18, Name = "Concrete Mixer Truck" },
                new { Id = 19, Name = "Garbage Truck" },
                new { Id = 20, Name = "Fire Truck" }
            );
        }
    }
}
