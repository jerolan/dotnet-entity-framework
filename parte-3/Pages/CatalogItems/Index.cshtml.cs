using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cf.Dotnet.EntityFramework.Parte2.Models;
using Cf.Dotnet.EntityFramework.Parte3;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.CatalogItems
{
    public class IndexModel : PageModel
    {
        private readonly Cf.Dotnet.EntityFramework.Parte3.DatabaseContext _context;

        public IndexModel(Cf.Dotnet.EntityFramework.Parte3.DatabaseContext context)
        {
            _context = context;
        }

        public IList<CatalogItem> CatalogItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CatalogItem = await _context.CatalogItems.ToListAsync();
        }
    }
}