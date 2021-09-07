using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace dealership.Pages.cars
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.VehicleContext _context;
        
        public IndexModel(WebApplication1.Models.VehicleContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; }
        public string category { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> CategoryQeuery = from cat in _context.Vehicles
                                                orderby cat.Category
                                                select cat.Category;
            /*
            if (!string.IsNullOrEmpty(category))
            {
                Vehicle = await Vehicle.Where(x => x.Category == category);

            }*/

            Vehicle = await _context.Vehicles.ToListAsync();
        }
        /*
        public async Task OnGetAsync()
        {
            Vehicle = await _context.Vehicles.ToListAsync();
        }*/

    }
}
