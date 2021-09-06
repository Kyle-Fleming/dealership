using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using dealership.Repositories;

namespace dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<vehicle>> Getvehicles()
        {
            return await _vehicleRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<vehicle>> Getvehicles(int id)
        {
            return await _vehicleRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<vehicle>> Postvehicles([FromBody] vehicle vehicle)
        {
            var newvehicle = await _vehicleRepository.Create(vehicle);
            return CreatedAtAction(nameof(Getvehicles), new { id = newvehicle.Id }, newvehicle);
        }

        [HttpPut]
        public async Task<ActionResult> Putvehicles(int id, [FromBody] vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            await _vehicleRepository.Update(vehicle);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var vehicleToDelete = await _vehicleRepository.Get(id);
            if (vehicleToDelete == null)
                return NotFound();

            await _vehicleRepository.Delete(vehicleToDelete.Id);
            return NoContent();
        }
    }
}
