using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApi.Application.DTOs
{
    public record VehicleQueryParameters
    {
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string Type { get; init; }
        public string Manufacturer { get; init; }
        public int? Year { get; init; }
    }
}
