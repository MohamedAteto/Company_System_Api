using Company_System_Api.Models;

namespace Company_System_Api.Reposatories.Interface
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        Task<ICollection<Employee>> GetByNameAsync(string name);
        Task<ICollection<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);

    }
}
