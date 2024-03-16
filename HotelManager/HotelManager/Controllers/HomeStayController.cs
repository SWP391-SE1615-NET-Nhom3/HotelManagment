using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class HomeStayController : Controller
    {
        public IActionResult listhomestay()
        {
            return View();
        }
        public IActionResult AddHomeStay()
        {
            return View();
        }
        public IActionResult UpdateHomeStay()
        {
            return View();
        }
        public IActionResult dashboard()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult ListHomeStaybyAdmin()
        {
            return View();
        }
    }
}
