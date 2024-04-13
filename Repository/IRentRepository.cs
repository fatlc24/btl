using BTLwebNC.Models;

namespace BTLwebNC.Repository
{
    public interface IRentRepository
    {
        List<TblTtxe> GetAllXe();
        TblUser getUser(int id);
        TblTtxe GetTtxe(int id);
        TblThuexe saveRent(int id);
        TblTtxe UpdateIscheck(int id);

    }
}
