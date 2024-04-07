using BTLwebNC.Models;
using Microsoft.Extensions.Hosting;

namespace BTLwebNC.Repository
{
    public interface INewsRepository
    {
        List<TblNews> GetAllNews();
        TblNews GetNewsByID(int id);
    }
}
