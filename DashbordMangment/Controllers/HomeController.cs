using Microsoft.AspNetCore.Mvc;

namespace DashbordMangment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
