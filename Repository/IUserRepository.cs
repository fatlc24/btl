using BTLwebNC.Models;

namespace BTLwebNC.Repository
{
    public interface IUserRepository
    {
        // list xe đã đăng ký thuê
        List<TblThuexe> GetThuexeList();
        // list xe đã đăng ký cho thuê
        List<TblTtxe> GetTtxeList();
        List<TblTtxe> GetTtxeByID(int id);
    }
}
