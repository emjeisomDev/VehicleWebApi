using VehicleWebApi.Application.DTOs;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<Car> CreateCarAsync(CreateCarDto dto);

        Task<Truck> CreateTruckAsync(CreateTruckDto dto);

        Task<Motorcycle> CreateMotorcycleAsync(CreateMotorcycleDto dto);
        Task<object> CreateVehicleAsync(CreateVehicleRequest request);
    }
}
