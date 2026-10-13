using Company_System_Api.Data;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company_System_Api.Reposatories.Implmentaion
{
    public class ProjectEmployeeRepo : GenericRepo<EmployeeProject>, IProjectsEmployeeRepo
    {

        private readonly AppDbContext _context;
        public ProjectEmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<EmployeeProject>> GetEmployeeProjectsByEmployeeIdAsync(int employeeId)
        {
            var items =  await _context.EmployeeProjects.Where(e => e.EmployeeId == employeeId).ToListAsync();
            return items;
        }
    }
}
