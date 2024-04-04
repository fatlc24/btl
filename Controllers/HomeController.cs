using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var usernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var idLogin = userClaims.FindFirst("IDUseName");
                var tenusername = userClaims.FindFirst("UseName");
                if (usernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string username = usernameClaim.Value;
                    TempData["Username"] = username1;
                    TempData["LoginData"] = username;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }
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
