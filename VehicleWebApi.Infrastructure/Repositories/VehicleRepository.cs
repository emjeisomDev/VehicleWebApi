using Microsoft.EntityFrameworkCore;
using VehicleWebApi.Application.DTOs;
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

        public async Task<IEnumerable<VehicleDto>> GetVehiclesAsync(VehicleQueryParameters query)
        {
            var vehicles = _context.Vehicles
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Type))
            {
                vehicles = vehicles.Where(v =>
                    v.VehicleType.Name.ToLower() == query.Type.ToLower());
            }

            if (!string.IsNullOrWhiteSpace(query.Manufacturer))
            {
                vehicles = vehicles.Where(v =>
                    v.ModelVersion.Model.Manufacturer.Name.ToLower() ==
                    query.Manufacturer.ToLower());
            }

            if (query.Year.HasValue)
            {
                vehicles = vehicles.Where(v =>
                    v.ModelVersion.Year == query.Year.Value);
            }

            return await vehicles
                .Select(v => new VehicleDto(
                    v.Id,
                    v.VehicleType.Name,
                    v.Color,
                    v.ModelVersionId,
                    v.ModelVersion.Year,
                    v.ModelVersion.Model.Name,
                    v.ModelVersion.Model.Manufacturer.Name
                ))
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

    }
}
