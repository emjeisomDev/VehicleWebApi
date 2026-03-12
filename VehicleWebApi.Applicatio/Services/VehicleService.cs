using VehicleWebApi.Application.DTOs.CreatesDTOs;
using VehicleWebApi.Application.DTOs.EntitiesDTOs;
using VehicleWebApi.Application.Interfaces;
using VehicleWebApi.Domain.Entities;
using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Application.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VehicleDto>> GetVehiclesAsync() => await _repository.GetVehiclesAsync();

        public async Task<VehicleDto> GetVehicleByIdAsync(int id) => await _repository.GetVehicleByIdAsync(id);

        public async Task<Car> CreateCarAsync(CreateCarDto dto)
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

            return car;
        }

        public async Task<Truck> CreateTruckAsync(CreateTruckDto dto)
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

            return truck;
        }

        public async Task<Motorcycle> CreateMotorcycleAsync(CreateMotorcycleDto dto)
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

            return motorcycle;
        }

        public async Task<object> CreateVehicleAsync(CreateVehicleRequest request)
        {
            switch (request.Type.ToLower())
            {
                case "car":

                    var carDto = new CreateCarDto(
                        request.Color,
                        request.ModelVersionId,
                        request.DoorsQuantity!.Value,
                        request.TrunkLiters,
                        request.HasSunroof,
                        request.BodyTypeId
                    );

                    await CreateCarAsync(carDto);

                    return carDto;

                case "truck":

                    var truckDto = new CreateTruckDto(
                        request.Color,
                        request.ModelVersionId,
                        request.LoadCapacityInTons!.Value,
                        request.AxlesQuantity,
                        request.BodyTypeId
                    );

                    await CreateTruckAsync(truckDto);

                    return truckDto;

                case "motorcycle":

                    var normalized = request.HandlebarType
                        .Replace("-", "")
                        .Replace(" ", "");

                    var handlebar = Enum.Parse<HandlebarType>(normalized, true);

                    var motoDto = new CreateMotorcycleDto(
                        request.Color,
                        request.ModelVersionId,
                        request.EngineDisplacement!.Value,
                        handlebar,
                        request.HasElectricStart
                    );

                    await CreateMotorcycleAsync(motoDto);

                    return motoDto;

                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
        }


    }
}
