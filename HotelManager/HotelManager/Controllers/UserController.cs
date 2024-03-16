using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> login()
        {
            return View();
        }
        public async Task<IActionResult> ListAccount()
        {
            return View();
        }
        public async Task<IActionResult> AddAcount()
        {
            return View();
        }

        public async Task<IActionResult> profileuser()
        {
            return View();
        }
    }
}
