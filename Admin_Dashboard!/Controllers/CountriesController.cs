using Microsoft.AspNetCore.Mvc;

namespace Admin_Dashboard_.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
