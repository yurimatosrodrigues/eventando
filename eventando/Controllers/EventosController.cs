using Microsoft.AspNetCore.Mvc;

namespace eventando.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
