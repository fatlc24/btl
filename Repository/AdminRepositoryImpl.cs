using BTLwebNC.Models;

namespace BTLwebNC.Repository
{
    public class AdminRepositoryImpl : IAdminRepositony
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly RentalDbContext _context;
        public AdminRepositoryImpl(IHttpContextAccessor httpContextAccessor, RentalDbContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public List<TblContact> GetTblContacts()
        {
            return _context.TblContacts.ToList();
        }

        public List<TblUser> GetTblUsers()
        {
            return _context.TblUsers.ToList();
        }
    }
}
