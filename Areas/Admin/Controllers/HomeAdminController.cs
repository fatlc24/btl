using BTLwebNC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTLwebNC.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]
    public class HomeAdminController : Controller
    {
        RentalDbContext db = new RentalDbContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
