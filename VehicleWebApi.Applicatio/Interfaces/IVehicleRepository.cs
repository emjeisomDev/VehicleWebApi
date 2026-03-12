using System;
using System.Collections.Generic;
using System.Text;
using VehicleWebApi.Application.DTOs.EntitiesDTOs;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle vehicle);
        Task SaveChangesAsync();
        Task<IEnumerable<VehicleDto>> GetVehiclesAsync();
        Task<VehicleDto?> GetVehicleByIdAsync(int id);
    }
}
