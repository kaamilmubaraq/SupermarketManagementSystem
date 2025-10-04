using Microsoft.AspNetCore.Mvc;

namespace tempAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {

            return View();
        }

            
    }
}
