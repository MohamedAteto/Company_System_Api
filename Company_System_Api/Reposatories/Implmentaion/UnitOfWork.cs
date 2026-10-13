using Company_System_Api.Data;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;

namespace Company_System_Api.Reposatories.Implmentaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepo Users { get; }

        public IGenericRepo<Department> Departments { get; }

        public IEmployeeRepo EmployeeRepo { get; }

        public IGenericRepo<Project> Projects { get; }

        public IProjectsEmployeeRepo projectsEmployeeRepo { get; }

        public UnitOfWork(IUserRepo users , AppDbContext context ,
            IGenericRepo<Department> departments , IEmployeeRepo employeeRepo
            , IGenericRepo<Project> project , IProjectsEmployeeRepo projectsEmployeeRepo)
        {
            Users = users;
            _context = context;
            Departments = departments;
            EmployeeRepo = employeeRepo;
            Projects = project;
            this.projectsEmployeeRepo = projectsEmployeeRepo;
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
