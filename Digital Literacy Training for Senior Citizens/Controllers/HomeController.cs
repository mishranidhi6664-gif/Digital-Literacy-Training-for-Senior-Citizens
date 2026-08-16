using Microsoft.AspNetCore.Mvc;
using DigitalLiteracyTraining.Models;
using System.Diagnostics;

namespace DigitalLiteracyTraining.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult Survey()
        {
            return View();
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