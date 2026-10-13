using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
