using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace dealership.Repositories
{
    public class vehicleRepository : IVehicleRepository
    {
        public readonly vehicleContext _context;

        public vehicleRepository(vehicleContext context)
        {
            _context = context;
        }

        public async Task<vehicle> Create(vehicle vehicle)
        {
            _context.vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }


        public async Task Delete(int id)
        {
            var vehicleToDelete = await _context.vehicles.FindAsync(id);
            _context.vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<vehicle>> Get()
        {
            return await _context.vehicles.ToListAsync();
        }

        public async Task<vehicle> Get(int id)
        {
            return await _context.vehicles.FindAsync(id);
        }

        public async Task Update(vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
