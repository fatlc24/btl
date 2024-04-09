using BTLwebNC.Models;


namespace BTLwebNC.Repository
{
    public interface IcontactRepository
    {
        TblContact Contact(TblContact Contact);
        //TblUser GetUser(string username);
        
    }
}
