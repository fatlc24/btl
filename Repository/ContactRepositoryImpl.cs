using BTLwebNC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;


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

        public TblContact Contact(TblContact Contact)
        {
            var principal = httpContextAccessor.HttpContext.User;
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {

                var user = _context.TblContacts.SingleOrDefault(p => p.IdUser == userId);
                TblContact result = new TblContact
                {
                    IdUser = userId,
                    Title = Contact.Title,
                    Content = Contact.Content,
                };
                _context.TblContacts.Add(result);
                _context.SaveChanges();
                return Contact;
            }
            return null;
        }

        //public TblUser GetUser(string username)
        //{
        //    username = httpContextAccessor.HttpContext.Session.GetString("username");
        //    return _context.TblUsers.Where(u => u.Username.Contains(username)).ToList();
        //}


    }
}
