using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BTLwebNC.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentRepository rentRepository;

        RentalDbContext db = new RentalDbContext();
        public RentController(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Rent()
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
            List<TblTtxe> ttxe = rentRepository.GetAllXe();

            return View(ttxe);
        }
        [HttpGet]
        public IActionResult Getuser(int id)
        {
            var resual = rentRepository.getUser(id);
            return Json(resual);
        }
        public IActionResult GetTtxe(int id)
        {
            var resual = rentRepository.GetTtxe(id);
            return Json(resual);
        }
        public IActionResult saveRent(int id)
        {
            var resual = rentRepository.saveRent(id);
            rentRepository.UpdateIscheck(id);
            //cần trả về vào myprofile
            return RedirectToAction("User", "MyProfile");
        }

    }
}
