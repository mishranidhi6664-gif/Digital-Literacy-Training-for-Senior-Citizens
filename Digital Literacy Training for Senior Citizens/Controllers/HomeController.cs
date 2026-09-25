using Digital_Literacy_Training_for_Senior_Citizens.Models;
using DigitalLiteracyTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DigitalLiteracyTraining.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Home
        public IActionResult Index()
        {
            return View();
        }

        // Learn
        public IActionResult Learn()
        {
            return View();
        }

        // Module 1 - Smartphone Basics
        public IActionResult Smartphone()
        {
            return View();
        }

        // Module 2 - Internet Skills
        public IActionResult Internet()
        {
            return View();
        }

        // Module 3 - Communication & WhatsApp
        public IActionResult Communication()
        {
            return View();
        }

        // Module 4 - Digital Payments
        public IActionResult DigitalPayments()
        {
            return View();
        }

        // Module 5 - Online Safety
        public IActionResult OnlineSafety()
        {
            return View();
        }

        // Tutorials
        public IActionResult Tutorials()
        {
            return View();
        }

        // Quiz
        public IActionResult Quiz()
        {
            return View();
        }

        // Survey
        [HttpGet]
        public IActionResult Survey()
        {
            return View();
        }

        // Submit Survey
        [HttpPost]
        public IActionResult SubmitSurvey(SurveyResponse response)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                response.UserEmail = User.Identity.Name;
            }

            response.SubmittedAt = DateTime.Now;

            _context.SurveyResponses.Add(response);
            _context.SaveChanges();

            return RedirectToAction("SurveySuccess");
        }

        // Survey Success
        [HttpGet]
        public IActionResult SurveySuccess()
        {
            return View();
        }

        // Survey Responses - Admin Only
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult SurveyResponses()
        {
            var responses = _context.SurveyResponses
                .OrderByDescending(x => x.SubmittedAt)
                .ToList();

            return View(responses);
        }

        // About
        public IActionResult About()
        {
            return View();
        }

        // Contact
        public IActionResult Contact()
        {
            return View();
        }

        // Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Error
        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}