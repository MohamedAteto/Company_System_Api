using AutoMapper;
using Company_System_Api.DTOs.AuthDTOs;
using Company_System_Api.DTOs.DepartmentDTOs;
using Company_System_Api.DTOs.EmployeeDTOs;
using Company_System_Api.DTOs.ProjectDTOs;
using Company_System_Api.DTOs.ProjectsEmployeeDTOs;
using Company_System_Api.Models;

namespace Company_System_Api.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<User, LoginDTO>().ReverseMap();

            CreateMap<Department,DepartmentDTO>().ReverseMap();
            CreateMap<Department,CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department,UpdateDepartmentDTO>().ReverseMap();

            CreateMap<Employee,EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();

            CreateMap<Project,ProjectDTO>().ReverseMap();
            CreateMap<Project,CreateProjectDTO>().ReverseMap();
            CreateMap<Project,UpdateProjectDTO>().ReverseMap();

            CreateMap<EmployeeProject, ProjectsEmployeeDTO>().ReverseMap();
            CreateMap<EmployeeProject, CreatePojectsEmployeeDTO>().ReverseMap();


        }
    }
}
