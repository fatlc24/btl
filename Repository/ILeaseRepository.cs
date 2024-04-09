using BTLwebNC.Models;

namespace BTLwebNC.Repository
{
    public interface ILeaseRepository
    {
        TblTtxe CreateLease(TblTtxe lease);
    }
}
