using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smarthack.Data;
using smarthack.Models;
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
            var rand = new Random();

            var news = await _context.Newses.Where(x => x.CompanyId == companyId).Select(x => new NewsView
            {
                Headline = "",
                Id = x.Id,
                Impact = (double)rand.Next(-700, 700) / 100,
                Link = x.Link,
                Time = DateTime.Now.AddDays(rand.Next(10))
            }).Take(10).ToListAsync();
            return Ok(new
            {
                Items = news.OrderBy(x => x.Time)
            });

        }


    }
}