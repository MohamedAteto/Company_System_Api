using Company_System_Api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.DTOs.ProjectsEmployeeDTOs
{
    public class ProjectsEmployeeDTO
    {
        public int id { get; set; }
        public string AssignedRole { get; set; }
        public DateTime AssignedDate { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
