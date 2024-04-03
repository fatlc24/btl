using BTLwebNC.Models;
using Microsoft.EntityFrameworkCore;

namespace BTLwebNC.Repository
{
    public class ContactRepositoryImpl : IcontactRepository
    {
        private readonly RentalDbContext _context;
        public ContactRepositoryImpl(RentalDbContext context)
        {
            _context = context;
        }

        TblContact IcontactRepository.sendContact(TblContact sendContact)
        {
            _context.TblContacts.Add(sendContact);
            _context.SaveChanges();
            return sendContact;
        }
    }
}
