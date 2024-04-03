using BTLwebNC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BTLwebNC.Controllers
{
    public class AccessController : Controller
    {
        RentalDbContext db = new RentalDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claims = HttpContext.User;
            if (claims.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
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
            if (userData.Username == null || userData.Password == null || userData.Name == null || userData.Phone == null || userData.Email == null)
            {
                return View(userData);
            }
            else
            {
                if (!NotEmpty(userData.Name))
                {
                    ModelState.AddModelError("Name", "The Name field is required.");
                    return View(userData);
                }
                if (!NotEmpty(userData.Phone))
                {
                    ModelState.AddModelError("Phone", "The Phone field is required.");
                    return View(userData);
                }
                if (!IsValidPhoneNumber(userData.Phone))
                {
                    ModelState.AddModelError("Phone", "Số điện thoại sai định dạng.");
                    return View(userData);
                }
                if (!NotEmpty(userData.Email))
                {
                    ModelState.AddModelError("Email", "The Email field is required.");
                    return View(userData);
                }
                if (!IsValidEmail(userData.Email))
                {
                    ModelState.AddModelError("Email", "Email sai định dạng.");
                    return View(userData);
                }
                var checkUsername = db.TblUsers.SingleOrDefault(x => x.Username == userData.Username);

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
                else
                {
                    db.TblUsers.Add(userData);
                    db.SaveChanges();
                    return RedirectToAction("Login");



                }
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
