using Company_System_Api.Data;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company_System_Api.Reposatories.Implmentaion
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
         private readonly AppDbContext _context;
         
        public EmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<ICollection<Employee>> GetByNameAsync(string name)
        {
            var items = await _context.Employees.Where(n => n.FullName.Contains(name)).ToListAsync();
            return items;
        }

        public async Task<ICollection<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var items = await _context.Employees.Where(d => d.DepartmentId == departmentId).ToListAsync();
            return items;
        }
    }
}
