using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Application.DTOs.CreatesDTOs;
using VehicleWebApi.Application.Interfaces;

namespace VehicleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public TrucksController(IVehicleService vehicleService) => _vehicleService = vehicleService;

        [HttpPost]
        public async Task<IActionResult> CreateTruck([FromBody] CreateTruckDto dto)
        {
            var id = await _vehicleService.CreateTruckAsync(dto);

            return CreatedAtAction(nameof(CreateTruck), new { id }, new { id });
        }
    }
}
