using Microsoft.AspNetCore.Mvc;

namespace Digital_Literacy_Training_for_Senior_Citizens.Controllers
{
    public class AdminController : Controller
    {
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
