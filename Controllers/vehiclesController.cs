using dealership.Repositories;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleRepository vehicleRepository;

        public VehiclesController()
        {
            _vehicleRepository = vehicleRepository;
        }



        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Getvehicles()
        {
            return await _vehicleRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Getvehicles(int id)
        {
            return await _vehicleRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> Postvehicles([FromBody] Vehicle vehicle)
        {
            var newvehicle = await _vehicleRepository.Create(vehicle);
            return CreatedAtAction(nameof(Getvehicles), new { id = newvehicle.ID }, newvehicle);
        }

        [HttpPut]
        public async Task<ActionResult> Putvehicles(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.ID)
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

            await _vehicleRepository.Delete(vehicleToDelete.ID);
            return NoContent();
        }


    }
}

