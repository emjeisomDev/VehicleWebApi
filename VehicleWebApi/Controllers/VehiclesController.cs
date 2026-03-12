using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Application.DTOs;
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

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleRequest request)
        {
            var result = await _service.CreateVehicleAsync(request);
            return Created("", result);
        }


    }
}
