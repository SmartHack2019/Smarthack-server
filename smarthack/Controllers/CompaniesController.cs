using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smarthack.Data;
using System.Threading.Tasks;

namespace smarthack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private SmartHackDbContext _context;
        public CompaniesController(SmartHackDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return Ok(new
            {
                Items = companies
            });
        }
    }
}