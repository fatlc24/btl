using BTLwebNC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BTLwebNC.Repository
{
    public class LeaseRepositoryImpl : ILeaseRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly RentalDbContext _context;
        public LeaseRepositoryImpl(RentalDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public TblTtxe CreateLease(TblTtxe lease)
        {
            var principal = httpContextAccessor.HttpContext.User;
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {

                var user = _context.TblTtxes.FirstOrDefault(p => p.IdUser == userId);
                TblTtxe result = new TblTtxe
                {
                    IdUser = userId,
                    Tenxe = lease.Tenxe,
                    Status = lease.Status,
                    Namsanxuat = lease.Namsanxuat,
                    Image = lease.Image,
                    Tien = lease.Tien,
                    Publish = 1,
                    IsCheck = "1",
                };
                _context.TblTtxes.Add(result);
                _context.SaveChanges();
                return lease;
            }
            
            return null;
        }
    }
}
