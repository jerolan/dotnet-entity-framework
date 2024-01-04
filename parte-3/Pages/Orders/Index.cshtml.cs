using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cf.Dotnet.EntityFramework.Parte2.Models;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Cf.Dotnet.EntityFramework.Parte3.DatabaseContext _context;
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? RangeStart { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? RangeEnd { get; set; }

        public IndexModel(Cf.Dotnet.EntityFramework.Parte3.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Orders.AsQueryable();

            if (RangeStart.HasValue)
            {

                query = query.Where(o => o.Quantity >= RangeStart.Value);
            }

            if (RangeEnd.HasValue)
            {
                query = query.Where(x => x.Quantity <= RangeEnd.Value);
            }
                
            Order = await query
                .Include(o => o.CatalogItem)
                .Include(o => o.Customer)
                .ToListAsync();
        }
    }
}
