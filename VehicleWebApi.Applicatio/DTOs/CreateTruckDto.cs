using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs
{
    public record CreateTruckDto : CreateVehicleDto
    {
        public decimal LoadCapacityInTons { get; init; }
        public int? AxlesQuantity { get; init; }
        public int? BodyTypeId { get; init; }

        public CreateTruckDto(
            string color,
            int modelVersionId,
            decimal loadCapacityInTons,
            int? axlesQuantity,
            int? bodyTypeId
        ) : base(color, modelVersionId)
        {
            LoadCapacityInTons = loadCapacityInTons;
            AxlesQuantity = axlesQuantity;
            BodyTypeId = bodyTypeId;
        }



    }
}
