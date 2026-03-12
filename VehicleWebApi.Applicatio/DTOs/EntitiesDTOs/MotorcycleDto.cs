using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs.EntitiesDTOs
{
    public record MotorcycleDto
    {
        public int Id { get; init; }
        public string Color { get; init; }
        public int EngineDisplacement { get; init; }
        public string HandlebarType { get; init; }
        public bool? HasElectricStart { get; init; }

        public MotorcycleDto(
            int id, 
            string color, 
            int engineDisplacement, 
            string handlebarType, 
            bool? hasElectricStart)
        {
            Id = id;
            Color = color;
            EngineDisplacement = engineDisplacement;
            HandlebarType = handlebarType;
            HasElectricStart = hasElectricStart;
        }
    }
}
