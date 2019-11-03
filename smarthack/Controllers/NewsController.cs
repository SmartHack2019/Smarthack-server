using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smarthack.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace smarthack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private SmartHackDbContext _context;
        public NewsController(SmartHackDbContext context)
        {
            _context = context;
        }


        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetNewsByCompany(Guid companyId)
        {
            var news = await _context.Newses.Where(x => x.CompanyId == companyId).ToListAsync();
            return Ok(new
            {
                Items = news
            });

        }


    }
}