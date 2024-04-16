using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace BTLwebNC.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepositony adminRepositony;
        public AdminController(IAdminRepositony adminRepositony)
        {
            this.adminRepositony = adminRepositony;
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
            return View();
        }
        public IActionResult AdminContact()
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
            var resultContact = new ModelsAdmin();
            var allContact = adminRepositony.GetTblContacts();
            var allUser = adminRepositony.GetTblUsers();
            resultContact.adminContact = allContact;
            resultContact.adminUser = allUser;
            return View(resultContact);
        }
        public IActionResult AdminNews()
        {
            var rusual = adminRepositony.GetAllNews();
            return View(rusual);
        }
        public IActionResult createNew()
        {

            return View();
        }
        [HttpPost]
        public IActionResult createNew(TblNews news)
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
            adminRepositony.createNew(news);
            return View();
        }
        [HttpDelete("deleteNewByID/{id}")]
        public IActionResult DeleteById(int id)
        {
            adminRepositony.deleteNewByID(id);
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult UpdateNew(int id, TblNews news)
        {
            var result = adminRepositony.updateNew(id, news);
            return RedirectToAction("AdminNews", "Admin");
        }
        [HttpGet]
        public IActionResult UpdateNew(int id)
        {
            var result = adminRepositony.getNewById(id);
            return View(result);
        }
    }
}
