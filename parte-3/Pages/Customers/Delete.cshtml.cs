using Cf.Dotnet.EntityFramework.Parte3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.Customers;

public class DeleteModel : PageModel
{
    private readonly DatabaseContext _context;

    public DeleteModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty] public Customer Customer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

        if (customer == null)
            return NotFound();
        Customer = customer;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            Customer = customer;
            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}