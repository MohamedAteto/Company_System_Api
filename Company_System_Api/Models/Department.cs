using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }


        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
