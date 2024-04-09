using BTLwebNC.Models;
using Microsoft.EntityFrameworkCore;

namespace BTLwebNC.Repository
{
    public class NewsRepositoryImpl : INewsRepository
    {
        private readonly RentalDbContext _context;
        public NewsRepositoryImpl(RentalDbContext context)
        {
            _context = context;
        }

        public List<TblNews> GetAllNews()
        {
            return _context.TblNews.ToList();
        }

        public List<TblNews> GetFirst5NewsSortedById()
        {
            var randomNews = _context.TblNews.OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            return randomNews;
        }

        public TblNews GetNewsByID(int id)
        {
            return _context.TblNews.FirstOrDefault(p => p.Id == id);
        }

    }
}
