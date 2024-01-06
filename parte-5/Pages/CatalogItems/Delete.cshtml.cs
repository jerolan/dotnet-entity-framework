using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cf.Dotnet.EntityFramework.Parte5.Models;
using Cf.Dotnet.EntityFramework.Parte5;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.CatalogItems
{
    public class DeleteModel : PageModel
    {
        private readonly Cf.Dotnet.EntityFramework.Parte5.DatabaseContext _context;

        public DeleteModel(Cf.Dotnet.EntityFramework.Parte5.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatalogItem CatalogItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogitem = await _context.CatalogItems.FirstOrDefaultAsync(m => m.Id == id);

            if (catalogitem == null)
            {
                return NotFound();
            }
            else
            {
                CatalogItem = catalogitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogitem = await _context.CatalogItems.FindAsync(id);
            if (catalogitem != null)
            {
                CatalogItem = catalogitem;
                _context.CatalogItems.Remove(CatalogItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
