using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs.CreatesDTOs
{
    public record CreateCarDto : CreateVehicleDto
    {
        public int DoorsQuantity { get; init; }
        public decimal? TrunkLiters { get; init; }
        public bool? HasSunroof { get; init; }
        public int? BodyTypeId { get; init; }

        public CreateCarDto(
            string color, 
            int modelVersionId, 
            int doorsQuantity, 
            decimal? trunkLiters, 
            bool? hasSunroof, 
            int? bodyTypeId
        ) : base(color, modelVersionId)
        {
            Color = color;
            ModelVersionId = modelVersionId;
            DoorsQuantity = doorsQuantity;
            TrunkLiters = trunkLiters;
            HasSunroof = hasSunroof;
            BodyTypeId = bodyTypeId;
        }




    }
}
