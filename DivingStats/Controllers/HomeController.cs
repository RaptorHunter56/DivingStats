using DivingStats.Data;
using DivingStats.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace DivingStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DiveDbContext _context;

        public HomeController(ILogger<HomeController> logger, DiveDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Diver diver = _context.Divers.First(x => x.ID == 1);
            Dictionary<int, decimal> Scores = _context.IndividualDives.Include(x => x.Dive).Where(x => x.DiverID == 1).ToList().GroupBy(x => x.RoundID).ToDictionary(x => x.First().RoundID, x => x.Sum(y => y.Score).Value);
            IEnumerable<Competition> competitions = _context.Competitions.Include(x => x.Rounds).OrderByDescending(x => x.EndDate).Take(3);
            AthleteProfileModel model = new AthleteProfileModel
            {
                FullName = diver.FirstName + "" + diver.LastName,
                Age = (int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(diver.DateOfBirth.Value.ToString("yyyyMMdd"))) / 10000,
                InstagramHandle = "nathan_nzdiver",
                FacebookPage = "https://www.facebook.com/p/Nathan-Brown-Diving-Athlete-100063552014956/",
                YoutubePage = "https://www.youtube.com/channel/UCZ38uAxknnO-lqw4fLi0JnA",
                GiveaLittlePage = "https://givealittle.co.nz/cause/olympic-qualification-journey-be-part-of-history",
                PersonalBestScore = Scores.Values.Max(),
                NationalTitles = new List<string> { "Winner of XYZ competition", "Runner-up of ABC competition" },
                Achievements = new List<string> { "Winner of XYZ competition", "Runner-up of ABC competition" },
                LastThreeCompetitionScores = competitions.Where(x => x.Rounds != null && x.EndDate.HasValue).Select(x => new CompetitionScoreModel(x.Name, Scores.Where(y => x.Rounds.Select(z => z.ID).Contains(y.Key)).Select(y => y.Value).DefaultIfEmpty(0).Max(), x.EndDate.Value)).ToList()
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}