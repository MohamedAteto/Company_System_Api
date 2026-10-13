using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Company_System_Api.Models
{
    public class EmployeeProject
    {
        [Key]
        public int id { get; set; }


        public string AssignedRole { get; set; }
        public DateTime AssignedDate { get; set; }



        public int EmployeeId { get; set; }
        [Required,ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        [Required, ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
