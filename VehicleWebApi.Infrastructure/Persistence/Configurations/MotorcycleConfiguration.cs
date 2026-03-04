using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleWebApi.Domain.Entities;
using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Infrastructure.Persistence.Configurations
{
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycle");

            builder.Property(m => m.EngineDisplacement)
                .IsRequired();

            builder.Property(m => m.HandlebarType)
                .HasConversion(new ValueConverter<HandlebarType, string>(
                    v => ConvertToString(v),
                    v => ConvertToEnum(v)))
                .HasMaxLength(50)
                .IsRequired();
        }

        private HandlebarType ConvertToEnum(string value)
        {
            return value switch
            {
                "Clip-Ons" => HandlebarType.ClipOns,
                "Ape Hangers" => HandlebarType.ApeHangers,
                "Drag Bars" => HandlebarType.DragBars,
                "Motocross" => HandlebarType.Motocross,
                "Riser" => HandlebarType.Riser,
                _ => throw new ArgumentException("Invalid handlebar type")
            };
        }

        private string ConvertToString(HandlebarType type)
        {
            return type switch
            {
                HandlebarType.ClipOns => "Clip-Ons",
                HandlebarType.ApeHangers => "Ape Hangers",
                HandlebarType.DragBars => "Drag Bars",
                HandlebarType.Motocross => "Motocross",
                HandlebarType.Riser => "Riser",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}