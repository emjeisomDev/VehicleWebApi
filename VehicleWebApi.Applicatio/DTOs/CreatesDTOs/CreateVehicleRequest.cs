using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs.CreatesDTOs
{
    public class CreateVehicleRequest
    {
        public string Type { get; init; }

        public string Color { get; init; }

        public int ModelVersionId { get; init; }

        public int? DoorsQuantity { get; init; }

        public decimal? TrunkLiters { get; init; }

        public bool? HasSunroof { get; init; }

        public decimal? LoadCapacityInTons { get; init; }

        public int? AxlesQuantity { get; init; }

        public int? BodyTypeId { get; init; }

        public int? EngineDisplacement { get; init; }

        public string HandlebarType { get; init; }

        public bool? HasElectricStart { get; init; }
    }
}
