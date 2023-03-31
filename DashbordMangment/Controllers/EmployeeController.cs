using Microsoft.AspNetCore.Mvc;

namespace DashbordMangment.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
