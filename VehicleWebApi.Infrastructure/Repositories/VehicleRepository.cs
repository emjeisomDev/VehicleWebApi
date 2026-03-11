using VehicleWebApi.Application.Interfaces;
using VehicleWebApi.Domain.Entities;
using VehicleWebApi.Infrastructure.Persistence;

namespace VehicleWebApi.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _context;
        public VehicleRepository(VehicleDbContext context) => _context = context;

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
