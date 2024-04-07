using BTLwebNC.Models;
using Microsoft.EntityFrameworkCore;


namespace BTLwebNC.Repository
{
    public class ContactRepositoryImpl : IcontactRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly RentalDbContext _context;
        public ContactRepositoryImpl(RentalDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        //public TblUser GetUser(string username)
        //{
        //    username = httpContextAccessor.HttpContext.Session.GetString("username");
        //    return _context.TblUsers.Where(u => u.Username.Contains(username)).ToList();
        //}

        TblContact IcontactRepository.sendContact(TblContact sendContact)
        {
            _context.TblContacts.Add(sendContact);
            _context.SaveChanges();
            return sendContact;
        }
    }
}
