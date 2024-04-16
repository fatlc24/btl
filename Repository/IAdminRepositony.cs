using BTLwebNC.Models;

namespace BTLwebNC.Repository
{
    public interface IAdminRepositony
    {
        List<TblUser> GetTblUsers();
        List<TblContact> GetTblContacts();
        List<TblNews> GetAllNews();
        TblNews createNew(TblNews news);
        void deleteNewByID(int id);
        TblNews getNewById(int id);
        TblNews updateNew(int id,TblNews news);
    }
}
