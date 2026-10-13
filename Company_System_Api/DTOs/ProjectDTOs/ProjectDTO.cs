using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.DTOs.ProjectDTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }
}
