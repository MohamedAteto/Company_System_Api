using Company_System_Api.Models;

namespace Company_System_Api.Reposatories.Interface
{
    public interface IProjectsEmployeeRepo : IGenericRepo<EmployeeProject>
    {
        Task<ICollection<EmployeeProject>> GetEmployeeProjectsByEmployeeIdAsync(int employeeId);
    }
}
