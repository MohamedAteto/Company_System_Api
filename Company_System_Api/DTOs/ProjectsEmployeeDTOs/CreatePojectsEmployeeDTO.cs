namespace Company_System_Api.DTOs.ProjectsEmployeeDTOs
{
    public class CreatePojectsEmployeeDTO
    {
        public string AssignedRole { get; set; }
        public DateTime AssignedDate { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
