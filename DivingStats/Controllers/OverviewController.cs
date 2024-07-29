using DivingStats.Data;
using DivingStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DivingStats.Controllers
{
    public class OverviewController : Controller
    {
        private readonly DiveDbContext _context;

        public OverviewController(DiveDbContext context)
        {
            _context = context;
        }

        public IActionResult Results()
        {
            IEnumerable<Competition> competitions = _context.Competitions.Include(x => x.Rounds).ThenInclude(x => x.IndividualDives).ThenInclude(x => x.Dive).OrderByDescending(x => x.EndDate);
            return View(competitions);
        }
    }
}
