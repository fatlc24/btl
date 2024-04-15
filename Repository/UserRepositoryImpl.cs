using BTLwebNC.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BTLwebNC.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly RentalDbContext _context;
        public UserRepositoryImpl(IHttpContextAccessor httpContextAccessor, RentalDbContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public List<TblThuexe> GetThuexeList()
        {
            var principal = httpContextAccessor.HttpContext.User;
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                var user = _context.TblThuexes.FirstOrDefault(u => u.IdUser == userId);
                if (user != null)
                {
                    var listthuexe = _context.TblThuexes.Where(p => p.IdUser == userId).ToList();
                    return listthuexe;
                }
            }
            return null;
        }

        public List<TblTtxe> GetTtxeByID(int id)
        {
            var principal = httpContextAccessor.HttpContext.User;
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                var user = _context.TblThuexes.FirstOrDefault(u => u.IdUser == userId);
                return _context.TblTtxes.Where(x => x.Id == id && x.IdUser == userId).ToList();
            }
            return null;
        }

        public List<TblTtxe> GetTtxeList()
        {
            var principal = httpContextAccessor.HttpContext.User;
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                var user = _context.TblTtxes.FirstOrDefault(u => u.IdUser == userId);
                if (user != null)
                {
                    var listttxe = _context.TblTtxes.Where(p => p.IdUser == userId).ToList();
                    return listttxe;
                }
            }
            return null;
        }
    }
}
