using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Application.DTOs;
using VehicleWebApi.Application.Interfaces;

namespace VehicleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public CarsController(IVehicleService vehicleService) => _vehicleService = vehicleService;

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarDto dto)
        {
            var id = await _vehicleService.CreateCarAsync(dto);
            return CreatedAtAction(nameof(CreateCar), new { id }, new { id });
        }
    }
}
