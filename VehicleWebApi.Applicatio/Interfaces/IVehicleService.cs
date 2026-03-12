using VehicleWebApi.Application.DTOs;
using VehicleWebApi.Application.DTOs.CreatesDTOs;
using VehicleWebApi.Application.DTOs.EntitiesDTOs;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<Car> CreateCarAsync(CreateCarDto dto);
        Task<Truck> CreateTruckAsync(CreateTruckDto dto);
        Task<Motorcycle> CreateMotorcycleAsync(CreateMotorcycleDto dto);
        Task<object> CreateVehicleAsync(CreateVehicleRequest request);
        Task<IEnumerable<VehicleDto>> GetVehiclesAsync();
        Task<VehicleDto?> GetVehicleByIdAsync(int id);
        Task<IEnumerable<VehicleDto>> GetVehiclesAsync(VehicleQueryParameters query);
    }
}
