using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages;

public class ReportModel : PageModel
{
    private readonly Cf.Dotnet.EntityFramework.Parte5.DatabaseContext _context;
    
    public IList<ReportItem> ReportItem { get; set; }

    public ReportModel(Cf.Dotnet.EntityFramework.Parte5.DatabaseContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        ReportItem = await _context.Database
            .SqlQueryRaw<ReportItem>("select * from OrderReports")
            .ToListAsync();
    }
    
    public async Task<IActionResult> OnPostRunSPAsync()
    {
        await _context.Database.ExecuteSqlRawAsync("EXEC GenerateOrderReports");
        return RedirectToPage();
    }
}