using Microsoft.EntityFrameworkCore;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Infrastructure.Persistence
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<ModelVersion> ModelVersions { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<BodyType> BodyTypes { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) 
            : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aplicar todas as configurações Fluent API automaticamente
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleDbContext).Assembly);
        }


    }
}
