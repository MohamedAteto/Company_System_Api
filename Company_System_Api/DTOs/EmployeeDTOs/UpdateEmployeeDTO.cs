namespace Company_System_Api.DTOs.EmployeeDTOs
{
    public class UpdateEmployeeDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
