using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class vehicleContext : DbContext
    {
        public vehicleContext(DbContextOptions<vehicleContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<vehicle> vehicles { get; set; }
    }
}
