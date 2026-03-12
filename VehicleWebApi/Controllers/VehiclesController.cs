using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Application.DTOs.CreatesDTOs;
using VehicleWebApi.Application.Interfaces;
using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehiclesController(IVehicleService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _service.GetVehicleByIdAsync(id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _service.GetVehiclesAsync();

            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleRequest request)
        {
            var result = await _service.CreateVehicleAsync(request);
            return Created("", result);
        }


    }
}
