using AutoMapper;
using Company_System_Api.DTOs.DepartmentDTOs;
using Company_System_Api.DTOs.EmployeeDTOs;
using Company_System_Api.Mapping;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_System_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var Entity = _mapper.Map<Employee>(DTO);

            await _unit.EmployeeRepo.Add(Entity);
            await _unit.SaveChangesAsync();

            return Ok(DTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _unit.EmployeeRepo.GetAllAsync();
            if (items is null)
                return NotFound("No Employees found");


            var DTOs = _mapper.Map<List<EmployeeDTO>>(items);

            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _unit.EmployeeRepo.GetByID(id);
            if (item is null)
                return NotFound("Employee not found");

            var DTO = _mapper.Map<EmployeeDTO>(item);
            return Ok(DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateEmployeeDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var item = await _unit.EmployeeRepo.GetByID(id);
            if (item is null)
                return NotFound("Employee not found");

            _mapper.Map(DTO, item);
            await _unit.SaveChangesAsync();
            return Ok(DTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var item = await _unit.Departments.GetByID(id);
            if (item is null)
                return NotFound("Department not found");

            var employees = await _unit.EmployeeRepo.GetByID(id);
            if (employees != null)
            {
                return BadRequest(new { message = "Cannot delete this department because it still has active employees." });
            }

            await _unit.Departments.Delete(id);
            await _unit.SaveChangesAsync();

            return Ok(new { message = "Department deleted successfully" });
        }

        [HttpGet("GetEmployeeByName")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var items = await _unit.EmployeeRepo.GetByNameAsync(name);

            if (items is null || !items.Any())
                return NotFound("No Employees found with the given name");

            var DTOs = _mapper.Map<List<EmployeeDTO>>(items);
            return Ok(DTOs);

        }

        [HttpGet("GetEmployeeByDepartmentId")]
        public async Task<IActionResult> GetEmployeeByDepartmentId(int departmentId)
        {
            var items = await _unit.EmployeeRepo.GetEmployeesByDepartmentIdAsync(departmentId);

            if (items is null || !items.Any())
                return NotFound("No Employees found for the given department ID");

            var DTOs = _mapper.Map<List<EmployeeDTO>>(items);
            return Ok(DTOs);
        }

    }
}

