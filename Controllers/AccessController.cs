using BTLwebNC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BTLwebNC.Controllers
{
    public class AccessController : Controller
    {
        RentalDbContext db = new RentalDbContext();
        private readonly IHttpContextAccessor httpContextAccessor;
        public AccessController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

        }

        public IActionResult Index()
        {
            ClaimsPrincipal claims = HttpContext.User;
            if (claims.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(TblUser userData)
        {
            if (userData.Username == null || userData.Password == null)
            {
                return View(userData);
            }
            else
            {
                var checkUsername = db.TblUsers.SingleOrDefault(x => x.Username == userData.Username && x.Password == userData.Password);

                if (!PasswordMeetsRequirements(userData.Password))
                {
                    ModelState.AddModelError("Password", "Mật khẩu cần chứa ít nhất một số và một chữ ");
                    return View(userData);
                }
                else if (userData.Password.Length < 7)
                {
                    ModelState.AddModelError("Password", "Mật khẩu phải lớn hơn 6 ký tự ");
                    return View(userData);
                }
                else if (userData.Username.Length < 4)
                {
                    ModelState.AddModelError("Username", "Tài khoản phải lớn hơn 4 ký tự ");
                    return View(userData);
                }

                else if (checkUsername == null)
                {
                    ModelState.AddModelError("Username", "Tài khoản không tồn tại hoặc sai mật khẩu ");
                    return View(userData);
                }
                else
                {
                    //if (userData.Username == "admin")
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}
                    //else
                    //{
                    //return RedirectToAction("Index", "Home");

                    //}
                    // sửa theo session

                    httpContextAccessor.HttpContext.Session.SetString("username", userData.Username);
                    // sử dụng claim
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, checkUsername.Id.ToString()),
                        new Claim("id_user",checkUsername.Id.ToString()),
                        new Claim("UseName",userData.Username),
                        new Claim("Name",checkUsername.Name),
                        new Claim("Email",checkUsername.Email),
                        new Claim("Phone",checkUsername.Phone),
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                    return RedirectToAction("Index", "Home");
                }
            }

        }
        //httpContextAccessor.HttpContext.Session.clear(); hàm logout 
        //public IActionResult Logout()
        //{
        //    httpContextAccessor.HttpContext.Session.Clear();
        //    httpContextAccessor.HttpContext.Session.Remove("username");
        //    return View("Login");
        //}
        public async Task<IActionResult> Register()
        {
            ClaimsPrincipal claims = HttpContext.User;
            if (claims.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //đăng ký
        [HttpPost]
        public async Task<IActionResult> Register(TblUser userData, string nlmatkhau)
        {
            if (userData.Name == null || userData.Phone == null || userData.Email == null || userData.Username == null || userData.Password == null)
            {
                return View(userData);
            }
            else
            {
                var checkUsername = db.TblUsers.SingleOrDefault(x => x.Username == userData.Username);
                if (!NotEmpty(userData.Name))
                {
                    ModelState.AddModelError("Name", "The Name field is required.");
                    return View(userData);
                }
                else
                if (!NotEmpty(userData.Phone))
                {
                    ModelState.AddModelError("Phone", "The Phone field is required.");
                    return View(userData);
                }
                else
                if (!IsValidPhoneNumber(userData.Phone))
                {
                    ModelState.AddModelError("Phone", "Số điện thoại sai định dạng.");
                    return View(userData);
                }
                else
                if (!NotEmpty(userData.Email))
                {
                    ModelState.AddModelError("Email", "The Email field is required.");
                    return View(userData);
                }
                else
                if (!IsValidEmail(userData.Email))
                {
                    ModelState.AddModelError("Email", "Email sai định dạng.");
                    return View(userData);
                }
                else


                if (!PasswordMeetsRequirements(userData.Password))
                {
                    ModelState.AddModelError("Password", "Mật khẩu cần chứa ít nhất một số và một chữ ");
                    return View(userData);
                }
                else if (userData.Password.Length < 7)
                {
                    ModelState.AddModelError("Password", "Mật khẩu phải lớn hơn 6 ký tự ");
                    return View(userData);
                }
                else if (userData.Username.Length < 5)
                {
                    ModelState.AddModelError("Username", "Tài khoản phải lớn hơn 4 ký tự ");
                    return View(userData);
                }

                else if (checkUsername != null)
                {
                    ModelState.AddModelError("Username", "Tài khoản đã tồn tại ");
                    return View(userData);
                }
                else if (userData.Password != nlmatkhau)
                {
                    TempData["Thông báo"] = "Mật khẩu không khớp!";
                    return View(userData);
                }
                var username = new SqlParameter("@username", userData.Username);
                var password = new SqlParameter("@password", userData.Password);
                var name = new SqlParameter("@name", userData.Name);
                var phone = new SqlParameter("@phone", userData.Phone);
                var email = new SqlParameter("@email", userData.Email);
                db.Database.ExecuteSqlRaw("EXEC pr_dangky @username,@password,@name,@phone,@email", username, password, name, phone, email);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

        }
        private bool PasswordMeetsRequirements(string password)
        {
            // Use a regular expression to check if the password contains at least one letter and one number
            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d).+$");
        }
        private bool NotEmpty(string fieldValue)
        {
            // Use a regular expression to check if the field is not empty (contains at least one character)
            return !string.IsNullOrEmpty(fieldValue) && !string.IsNullOrWhiteSpace(fieldValue);
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrWhiteSpace(phoneNumber) && System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$");
        }

        private bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && !string.IsNullOrWhiteSpace(email) && System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

    }
}
