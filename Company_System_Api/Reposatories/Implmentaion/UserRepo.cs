using Company_System_Api.Data;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company_System_Api.Reposatories.Implmentaion
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetByUserName(string username)
        {
            var item = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return item;
        }
    }
}
