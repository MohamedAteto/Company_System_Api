using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_System_Api.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,Range(3000,100000)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department department { get; set; }


        public ICollection<EmployeeProject> ProjectsEmployees { get; set; } = new List<EmployeeProject>();

    }
}
