using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.DTOs.DepartmentDTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

    }
}
