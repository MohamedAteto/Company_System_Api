using AutoMapper;
using Company_System_Api.DTOs.EmployeeDTOs;
using Company_System_Api.DTOs.ProjectsEmployeeDTOs;
using Company_System_Api.Mapping;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_System_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsEmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ProjectsEmployeeController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreatePojectsEmployeeDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var Entity = _mapper.Map<EmployeeProject>(DTO);

            await _unit.projectsEmployeeRepo.Add(Entity);
            await _unit.SaveChangesAsync();

            return Ok(DTO);
        }

        [HttpGet("Get Projects With EmployeeID")]
        public async Task<IActionResult> GetProjectsWithEmployeeID(int EmployeeID)
        {
            var items = await _unit.projectsEmployeeRepo.GetEmployeeProjectsByEmployeeIdAsync(EmployeeID);
            if (items is null)
                return NotFound("No Projects found for this Employee");


            var DTOs = _mapper.Map<List<ProjectsEmployeeDTO>>(items);
            return Ok(DTOs);
        }
    }
}
