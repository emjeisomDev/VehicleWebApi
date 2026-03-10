using System;
using System.Collections.Generic;
using System.Text;
using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Application.DTOs
{
    public record CreateMotorcycleDto : CreateVehicleDto
    {
        public int EngineDisplacement { get; init; }
        public HandlebarType HandlebarType { get; init; }
        public bool? HasElectricStart { get; init; }

        public CreateMotorcycleDto(
        string color,
        int modelVersionId,
        int engineDisplacement,
        HandlebarType handlebarType,
        bool? hasElectricStart
        ) : base(color, modelVersionId)
        {
            EngineDisplacement = engineDisplacement;
            HandlebarType = handlebarType;
            HasElectricStart = hasElectricStart;
        }




    }
}
