using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace dealership.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public readonly VehicleContext _context;

        public VehicleRepository(VehicleContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }


        public async Task Delete(int id)
        {
            var vehicleToDelete = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> Get(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }
        public async Task<Vehicle> Get(string Category)
        {
            return await _context.Vehicles.FindAsync(Category);
        }


        public async Task Update(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
