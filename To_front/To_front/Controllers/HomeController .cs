using Microsoft.AspNetCore.Mvc;

namespace To_front.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
