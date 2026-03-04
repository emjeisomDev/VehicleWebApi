using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class ModelVersionConfiguration : IEntityTypeConfiguration<ModelVersion>
    {
        public void Configure(EntityTypeBuilder<ModelVersion> builder)
        {
            builder.ToTable("ModelVersion");

            builder.HasKey(mv => mv.Id);

            builder.Property(mv => mv.Year)
                .IsRequired();

            builder.HasIndex(mv => new { mv.ModelId, mv.Year })
                .IsUnique();

            builder.HasOne(mv => mv.Model)
                .WithMany(m => m.Versions)
                .HasForeignKey(mv => mv.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
