using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace dealership.Repositories
{
    public class IVehicleRepository
    {
        Task<IEnumerable<vehicle>> Get();
        Task<vehicle> Get(int id);
        Task<vehicle> Create(vehicle vehicle);
        Task Update(vehicle vehicle);
        Task Delete(int id);
    }
}
