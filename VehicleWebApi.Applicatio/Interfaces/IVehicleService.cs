using VehicleWebApi.Application.DTOs;

namespace VehicleWebApi.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<int> CreateCarAsync(CreateCarDto dto);

        Task<int> CreateTruckAsync(CreateTruckDto dto);

        Task<int> CreateMotorcycleAsync(CreateMotorcycleDto dto);
    }
}
