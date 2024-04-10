using Microsoft.AspNetCore.Mvc;

namespace BTLwebNC.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
