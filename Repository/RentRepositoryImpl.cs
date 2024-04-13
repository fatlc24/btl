using BTLwebNC.Controllers;
using BTLwebNC.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BTLwebNC.Repository
{
    public class RentRepositoryImpl : IRentRepository
    {
        private readonly ILogger<RentRepositoryImpl> _logger;
        private readonly RentalDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public RentRepositoryImpl(ILogger<RentRepositoryImpl> logger, RentalDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }
        public List<TblTtxe> GetAllXe()
        {
            return _context.TblTtxes.Where(x => x.Publish == 1 && x.IsCheck == "1").ToList();
        }

        public TblTtxe GetTtxe(int id)
        {
            return _context.TblTtxes.Find(id);
        }

        public TblUser getUser(int id)
        {
            return _context.TblUsers.Find(id);
        }

        public TblThuexe saveRent(int id)
        {
            var principal = httpContextAccessor.HttpContext.User;
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {

                var user = _context.TblThuexes.FirstOrDefault(p => p.IdUser == userId);

                TblThuexe result = new TblThuexe
                {
                    IdUser = userId,
                    IdTtxe = id,

                };
                _context.TblThuexes.Add(result);
                _context.SaveChanges();
                return result;
            }
            return null;

        }

        public TblTtxe UpdateIscheck(int id)
        {
            var item = _context.TblTtxes.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsCheck = "0";
                _context.TblTtxes.Update(item);
                _context.SaveChanges();
            }
            return item;
        }
    }
}
