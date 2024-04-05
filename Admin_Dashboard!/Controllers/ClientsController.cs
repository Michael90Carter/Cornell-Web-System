using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Dashboard_.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
