using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_System_Api.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required , Range(1000,10000000)]
        public decimal Budget { get; set; }


        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId") , Required]
        public Department department { get; set; }

        public ICollection<EmployeeProject> ProjectsEmployees { get; set; } = new List<EmployeeProject>();



    }
}
