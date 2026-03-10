using VehicleWebApi.Application.DTOs;
using VehicleWebApi.Application.Interfaces;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Application.Services
{
    public class VehicleService : IVehicleService
    {
        public Task<int> CreateCarAsync(CreateCarDto dto)
        {
            var car = new Car(
                dto.Color,
                dto.ModelVersionId,
                dto.DoorsQuantity,
                dto.TrunkLiters,
                dto.HasSunroof,
                dto.BodyTypeId
            );

            return Task.FromResult(0);
        }

        public Task<int> CreateTruckAsync(CreateTruckDto dto)
        {
            var truck = new Truck(
                dto.Color,
                dto.ModelVersionId,
                dto.LoadCapacityInTons,
                dto.AxlesQuantity,
                dto.BodyTypeId
            );

            return Task.FromResult(0);
        }

        public Task<int> CreateMotorcycleAsync(CreateMotorcycleDto dto)
        {
            var motorcycle = new Motorcycle(
                dto.Color,
                dto.ModelVersionId,
                dto.EngineDisplacement,
                dto.HandlebarType,
                dto.HasElectricStart
            );

            return Task.FromResult(0);
        }
    }
}
