using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cf.Dotnet.EntityFramework.Parte2.Models;
using Cf.Dotnet.EntityFramework.Parte3;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.CatalogItems
{
    public class CreateModel : PageModel
    {
        private readonly Cf.Dotnet.EntityFramework.Parte3.DatabaseContext _context;

        public CreateModel(Cf.Dotnet.EntityFramework.Parte3.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CatalogItem CatalogItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CatalogItems.Add(CatalogItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
