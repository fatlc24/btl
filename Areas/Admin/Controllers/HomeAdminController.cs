using Microsoft.AspNetCore.Mvc;

namespace BTLwebNC.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
