using BTLwebNC.Models;
using Humanizer.Localisation;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

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

        public TblNews createNew(TblNews news)
        {
            //var principal = httpContextAccessor.HttpContext.User;
            //var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            //{


            TblNews result = new TblNews
            {
                IdUser = 6,
                Time = DateTime.Now,
                Image = news.Image,
                Content = news.Content,
                Name = news.Name,
            };
            _context.TblNews.Add(result);
            _context.SaveChanges();
            return news;
            //}
            //return null;
        }

        public void deleteNewByID(int id)
        {
            var result = _context.TblNews.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.TblNews.Remove(result);
                _context.SaveChanges();
            }
        }

        public List<TblNews> GetAllNews()
        {
            return _context.TblNews.Where(n => n.IdUser == 6).ToList();
        }

        public TblNews getNewById(int id)
        {
            return _context.TblNews.FirstOrDefault(p => p.Id == id);
        }

        public List<TblContact> GetTblContacts()
        {
            return _context.TblContacts.ToList();
        }

        public List<TblUser> GetTblUsers()
        {
            return _context.TblUsers.ToList();
        }

        public TblNews updateNew(int id, TblNews news)
        {
            var item = _context.TblNews.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {

                item.Content = news.Content;
                item.Name = news.Name;
                item.Image = news.Image;
                item.Time = DateTime.Now;
                item.IdUser = 6;
                _context.TblNews.Update(item);
                _context.SaveChanges();
            }


            return news;
        }
    }
}
