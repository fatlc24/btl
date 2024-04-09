using BTLwebNC.Models;
using Microsoft.Extensions.Hosting;

namespace BTLwebNC.Repository
{
    public interface INewsRepository
    {
        List<TblNews> GetAllNews();
        List<TblNews> GetFirst5NewsSortedById();
        TblNews GetNewsByID(int id);
    }
}
