using VehicleWebApi.Application.DTOs;
using VehicleWebApi.Application.Interfaces;
using VehicleWebApi.Domain.Entities;

namespace VehicleWebApi.Application.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository) => _repository = repository;

        public async Task<int> CreateCarAsync(CreateCarDto dto)
        {
            var car = new Car(
                dto.Color,
                dto.ModelVersionId,
                dto.DoorsQuantity,
                dto.TrunkLiters,
                dto.HasSunroof,
                dto.BodyTypeId
            );

            await _repository.AddAsync(car);
            await _repository.SaveChangesAsync();

            return car.Id;
        }

        public async Task<int> CreateTruckAsync(CreateTruckDto dto)
        {
            var truck = new Truck(
                dto.Color,
                dto.ModelVersionId,
                dto.LoadCapacityInTons,
                dto.AxlesQuantity,
                dto.BodyTypeId
            );

            await _repository.AddAsync(truck);
            await _repository.SaveChangesAsync();

            return truck.Id;
        }

        public async Task<int> CreateMotorcycleAsync(CreateMotorcycleDto dto)
        {
            var motorcycle = new Motorcycle(
                dto.Color,
                dto.ModelVersionId,
                dto.EngineDisplacement,
                dto.HandlebarType,
                dto.HasElectricStart
            );

            await _repository.AddAsync(motorcycle);
            await _repository.SaveChangesAsync();

            return motorcycle.Id;
        }
    }
}
