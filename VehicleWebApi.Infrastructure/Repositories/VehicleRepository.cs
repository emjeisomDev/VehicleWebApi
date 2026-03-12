using Microsoft.EntityFrameworkCore;
using VehicleWebApi.Application.DTOs.EntitiesDTOs;
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

        public async Task<IEnumerable<VehicleDto>> GetVehiclesAsync()
        {
            return await _context.Vehicles
                .AsNoTracking()
                .Select(v => new VehicleDto(
                    v.Id,
                    v.VehicleType.Name,
                    v.Color,
                    v.ModelVersionId,
                    v.ModelVersion.Year,
                    v.ModelVersion.Model.Name,
                    v.ModelVersion.Model.Manufacturer.Name
                ))
                .ToListAsync();
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles
                .AsNoTracking()
                .Where(v => v.Id == id)
                .Select(v => new VehicleDto(
                    v.Id,
                    v.VehicleType.Name,
                    v.Color,
                    v.ModelVersionId,
                    v.ModelVersion.Year,
                    v.ModelVersion.Model.Name,
                    v.ModelVersion.Model.Manufacturer.Name
                ))
                .FirstOrDefaultAsync();
        }

    }
}
