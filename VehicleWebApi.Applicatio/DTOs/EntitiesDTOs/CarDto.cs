using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs.EntitiesDTOs
{
    public record CarDto
    {

        public int Id { get; init; }
        public string Color { get; init; }
        public int DoorsQuantity { get; init; }
        public decimal? TrunkLiters { get; init; }
        public bool? HasSunroof { get; init; }
        public string BodyType { get; init; }

        public CarDto(
            int id,
            string color,
            int doorsQuantity,
            decimal? trunkLiters,
            bool? hasSunroof,
            string bodyType)
        {
            Id = id;
            Color = color;
            DoorsQuantity = doorsQuantity;
            TrunkLiters = trunkLiters;
            HasSunroof = hasSunroof;
            BodyType = bodyType;
        }



    }
}
