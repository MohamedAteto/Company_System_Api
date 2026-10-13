using Company_System_Api.Models;

namespace Company_System_Api.Reposatories.Interface
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User> GetByUserName(string username);
    }
}
