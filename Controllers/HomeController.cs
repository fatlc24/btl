using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTLwebNC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IcontactRepository repository;

        public HomeController(ILogger<HomeController> logger, IcontactRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult usermanual()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendContact(TblContact sendContact)
        {
            repository.sendContact(sendContact);
            return View("contact");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
