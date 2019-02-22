using GigHub_Fundamental.Models;
using GigHub_Fundamental.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub_Fundamental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        {
            var upComingGigs = _context.Gigs.
                Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.IsCanceled == false)
                .ToList();
            // .Where(g => g.DateTime > DateTime.Now);
            if (!String.IsNullOrWhiteSpace(query))
            {
                upComingGigs = upComingGigs.Where(g =>
                    g.Artist.Name.Contains(query) ||
                    g.Genre.Name.Contains(query) ||
                    g.Venue.Contains(query)).ToList();
            }

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upComingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "All Upcoming Gigs",
                SearchTearm = query

            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}