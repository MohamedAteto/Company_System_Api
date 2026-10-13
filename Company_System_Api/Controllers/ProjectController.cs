using AutoMapper;
using Company_System_Api.DTOs.EmployeeDTOs;
using Company_System_Api.DTOs.ProjectDTOs;
using Company_System_Api.Mapping;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_System_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ProjectController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrject(CreateProjectDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var Entity = _mapper.Map<Project>(DTO);

            await _unit.Projects.Add(Entity);
            await _unit.SaveChangesAsync();

            return Ok(DTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _unit.Projects.GetAllAsync();
            if (items is null)
                return NotFound("No Projects found");


            var DTOs = _mapper.Map<List<ProjectDTO>>(items);

            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _unit.Projects.GetByID(id);
            if (item is null)
                return NotFound("Project not found");

            var DTO = _mapper.Map<ProjectDTO>(item);
            return Ok(DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateProjectDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var item = await _unit.Projects.GetByID(id);
            if (item is null)
                return NotFound("Employee not found");

            _mapper.Map(DTO, item);
            await _unit.SaveChangesAsync();
            return Ok(DTO);
        }
    }
}
