using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Movies;

namespace WebApplication1.ControllerBase;

[Route("api/companies")]
[ApiController]
public class CompaniesApiController : Controller
{
    private readonly MoviesContext _context;

    public CompaniesApiController(MoviesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string filter)
    {
        return Ok(_context.ProductionCompanies
            .Where(o => o.CompanyName.ToLower().Contains(filter.ToLower()))
            .OrderBy(o => o.CompanyName)
            .AsNoTracking()
            .AsEnumerable()
        );
    }
    
}