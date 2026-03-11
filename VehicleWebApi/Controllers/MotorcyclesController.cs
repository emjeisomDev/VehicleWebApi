using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Application.DTOs;
using VehicleWebApi.Application.Interfaces;

namespace VehicleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public MotorcyclesController(IVehicleService vehicleService) => _vehicleService = vehicleService;

        [HttpPost]
        public async Task<IActionResult> CreateMotorcycle([FromBody] CreateMotorcycleDto dto)
        {
            var id = await _vehicleService.CreateMotorcycleAsync(dto);

            return CreatedAtAction(nameof(CreateMotorcycle), new { id }, new { id });
        }

    }
}
