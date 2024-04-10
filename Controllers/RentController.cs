using Microsoft.AspNetCore.Mvc;

namespace BTLwebNC.Controllers
{
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
