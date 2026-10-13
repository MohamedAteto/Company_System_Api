using Company_System_Api.Models;

namespace Company_System_Api.Reposatories.Interface
{
    public interface IUnitOfWork
    {
        IUserRepo Users { get; }
        IGenericRepo<Department> Departments { get; }
        IGenericRepo<Project> Projects { get; }
        IEmployeeRepo EmployeeRepo { get; }
        IProjectsEmployeeRepo projectsEmployeeRepo { get; }
        Task SaveChangesAsync();
    }
}
