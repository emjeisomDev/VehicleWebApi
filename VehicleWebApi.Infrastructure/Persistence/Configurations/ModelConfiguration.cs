using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(m => new { m.ManufacturerId, m.Name })
                .IsUnique();

            builder.HasOne(m => m.Manufacturer)
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
