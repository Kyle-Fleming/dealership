using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace dealership.Repositories
{
    interface IVehicleRepository
    {

        Task<IEnumerable<Vehicle>> Get();
        Task<Vehicle> Get(int ID);
        Task<Vehicle> Create(Vehicle vehicle);
        Task Update(Vehicle vehicle);
        Task Delete(int id);
    }
}
