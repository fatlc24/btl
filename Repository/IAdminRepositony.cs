using BTLwebNC.Models;

namespace BTLwebNC.Repository
{
    public interface IAdminRepositony
    {
        List<TblUser> GetTblUsers();
        List<TblContact> GetTblContacts();
    }
}
