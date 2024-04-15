using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BTLwebNC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IRentRepository rentRepository;
        public UserController(IUserRepository userRepository, IRentRepository rentRepository)
        {
            this.userRepository = userRepository;
            this.rentRepository = rentRepository;
        }
        public IActionResult Index()
        {
            return View("MyProfile");
        }
        public IActionResult MyProfile()
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
            var result = new MyProfile();
            var ListTtxe = userRepository.GetTtxeList();
            var ListThuexe = userRepository.GetThuexeList();
            result.Listttxe = ListTtxe;
            result.ListThuexe = ListThuexe;
            var ttxeByID = rentRepository.GetAllXeIScheckfalse();
            result.tblTtxes = ttxeByID;
            return View(result);
        }
    }
}
