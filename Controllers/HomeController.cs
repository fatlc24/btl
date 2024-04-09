using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.Extensions.Hosting;

namespace BTLwebNC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IcontactRepository repository;
        private INewsRepository newsRepository;

        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IcontactRepository repository, IHttpContextAccessor httpContextAccessor, INewsRepository newsRepository)
        {
            _logger = logger;
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
            this.newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var idusernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var tenusername = userClaims.FindFirst("UseName");
                var name = userClaims.FindFirst("Name");
                var email = userClaims.FindFirst("Email");
                var phone = userClaims.FindFirst("Phone");
                var id_user = userClaims.FindFirst("id_user");
                if (idusernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string tendangnhap = name.Value;
                    string emaildangnhap = email.Value;
                    string phonedangnhap = phone.Value;
                    string id = id_user.Value;
                    TempData["Username"] = username1;
                    TempData["idLoginData"] = idusernameClaim;
                    TempData["LoginData_name"] = tendangnhap;
                    TempData["LoginEmail"] = emaildangnhap;
                    TempData["LoginPhone"] = phonedangnhap;
                    TempData["id_user"] = id;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }
            List<TblNews> news = newsRepository.GetAllNews();

            return View(news);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult usermanual()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var idusernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var tenusername = userClaims.FindFirst("UseName");
                var name = userClaims.FindFirst("Name");
                var email = userClaims.FindFirst("Email");
                var phone = userClaims.FindFirst("Phone");
                var id_user = userClaims.FindFirst("id_user");
                if (idusernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string tendangnhap = name.Value;
                    string emaildangnhap = email.Value;
                    string phonedangnhap = phone.Value;
                    string id = id_user.Value;
                    TempData["Username"] = username1;
                    TempData["idLoginData"] = idusernameClaim;
                    TempData["LoginData_name"] = tendangnhap;
                    TempData["LoginEmail"] = emaildangnhap;
                    TempData["LoginPhone"] = phonedangnhap;
                    TempData["id_user"] = id;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }
            return View();
        }
        public IActionResult contact()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var idusernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var tenusername = userClaims.FindFirst("UseName");
                var name = userClaims.FindFirst("Name");
                var email = userClaims.FindFirst("Email");
                var phone = userClaims.FindFirst("Phone");
                var id_user = userClaims.FindFirst("id_user");
                if (idusernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string tendangnhap = name.Value;
                    string emaildangnhap = email.Value;
                    string phonedangnhap = phone.Value;
                    string id = id_user.Value;
                    TempData["Username"] = username1;
                    TempData["idLoginData"] = idusernameClaim;
                    TempData["LoginData_name"] = tendangnhap;
                    TempData["LoginEmail"] = emaildangnhap;
                    TempData["LoginPhone"] = phonedangnhap;
                    TempData["id_user"] = id;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }
            return View();
        }
        [HttpPost]
        public IActionResult Contact(TblContact sendContact)
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var idusernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var tenusername = userClaims.FindFirst("UseName");
                var name = userClaims.FindFirst("Name");
                var email = userClaims.FindFirst("Email");
                var phone = userClaims.FindFirst("Phone");
                var id_user = userClaims.FindFirst("id_user");
                if (idusernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string tendangnhap = name.Value;
                    string emaildangnhap = email.Value;
                    string phonedangnhap = phone.Value;
                    string id = id_user.Value;
                    TempData["Username"] = username1;
                    TempData["idLoginData"] = idusernameClaim;
                    TempData["LoginData_name"] = tendangnhap;
                    TempData["LoginEmail"] = emaildangnhap;
                    TempData["LoginPhone"] = phonedangnhap;
                    TempData["id_user"] = id;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }
            repository.Contact(sendContact);
            return View("contact");
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }
        public IActionResult news()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var idusernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var tenusername = userClaims.FindFirst("UseName");
                var name = userClaims.FindFirst("Name");
                var email = userClaims.FindFirst("Email");
                var phone = userClaims.FindFirst("Phone");
                var id_user = userClaims.FindFirst("id_user");
                if (idusernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string tendangnhap = name.Value;
                    string emaildangnhap = email.Value;
                    string phonedangnhap = phone.Value;
                    string id = id_user.Value;
                    TempData["Username"] = username1;
                    TempData["idLoginData"] = idusernameClaim;
                    TempData["LoginData_name"] = tendangnhap;
                    TempData["LoginEmail"] = emaildangnhap;
                    TempData["LoginPhone"] = phonedangnhap;
                    TempData["id_user"] = id;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }
            List<TblNews> news = newsRepository.GetAllNews();
            return View(news);
        }
        public IActionResult NewsDetail(int id)
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims != null)
            {
                // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
                var idusernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                var tenusername = userClaims.FindFirst("UseName");
                var name = userClaims.FindFirst("Name");
                var email = userClaims.FindFirst("Email");
                var phone = userClaims.FindFirst("Phone");
                var id_user = userClaims.FindFirst("id_user");
                if (idusernameClaim != null)
                {
                    string username1 = tenusername.Value;
                    string tendangnhap = name.Value;
                    string emaildangnhap = email.Value;
                    string phonedangnhap = phone.Value;
                    TempData["Username"] = username1;
                    TempData["idLoginData"] = idusernameClaim;
                    TempData["LoginData_name"] = tendangnhap;
                    TempData["LoginEmail"] = emaildangnhap;
                    TempData["LoginPhone"] = phonedangnhap;
                    // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
                }

                // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
            }

            var resultNews = new ModelsNews();
            var newsdetail = newsRepository.GetNewsByID(id);
            var listNews = newsRepository.GetFirst5NewsSortedById();
            resultNews.NewsDetail = newsdetail;
            resultNews.ListNews = listNews;
            return View(resultNews);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
