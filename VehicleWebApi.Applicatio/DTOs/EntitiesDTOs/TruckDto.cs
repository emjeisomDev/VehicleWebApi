using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs.EntitiesDTOs
{
    public record TruckDto
    {
        public int Id { get; init; }
        public string Color { get; init; }
        public decimal LoadCapacityInTons { get; init; }
        public int? AxlesQuantity { get; init; }
        public string BodyType { get; init; }

        public TruckDto(
            int id,
            string color,
            decimal loadCapacityInTons,
            int? axlesQuantity,
            string bodyType)
        {
            Id = id;
            Color = color;
            LoadCapacityInTons = loadCapacityInTons;
            AxlesQuantity = axlesQuantity;
            BodyType = bodyType;
        }
    }
}
