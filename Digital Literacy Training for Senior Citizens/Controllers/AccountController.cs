using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Digital_Literacy_Training_for_Senior_Citizens.Models;

namespace Digital_Literacy_Training_for_Senior_Citizens.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string ConfirmPassword)
        {
            if (user.Password != ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View(user);
            }

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                ViewBag.Error = "Email is already registered.";
                return View(user);
            }

            user.Password = _passwordHasher.HashPassword(user, user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == Email);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.Password,
                Password
            );

            if (result == PasswordVerificationResult.Failed)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            user.LastLogin = DateTime.Now;
            _context.SaveChanges();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return RedirectToAction("Login");
        }
    }
}