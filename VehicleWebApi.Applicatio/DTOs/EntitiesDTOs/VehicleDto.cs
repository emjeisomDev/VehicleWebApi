using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs.EntitiesDTOs
{
    public record VehicleDto
    {
        public int Id { get; init; }
        public string Type { get; init; }
        public string Color { get; init; }
        public int ModelVersionId { get; init; }
        public int Year { get; init; }
        public string Model { get; init; }
        public string Manufacturer { get; init; }

        public VehicleDto(
            int id,
            string type,
            string color,
            int modelVersionId,
            int year,
            string model,
            string manufacturer)
        {
            Id = id;
            Type = type;
            Color = color;
            ModelVersionId = modelVersionId;
            Year = year;
            Model = model;
            Manufacturer = manufacturer;
        }


    }
}
