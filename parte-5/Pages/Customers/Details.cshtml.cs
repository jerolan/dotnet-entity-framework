using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cf.Dotnet.EntityFramework.Parte5.Models;
using Cf.Dotnet.EntityFramework.Parte5;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Cf.Dotnet.EntityFramework.Parte5.DatabaseContext _context;

        public DetailsModel(Cf.Dotnet.EntityFramework.Parte5.DatabaseContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
