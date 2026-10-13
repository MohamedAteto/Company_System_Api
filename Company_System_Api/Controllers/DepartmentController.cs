using AutoMapper;
using Company_System_Api.DTOs.DepartmentDTOs;
using Company_System_Api.Mapping;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_System_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DepartmentController( IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var Entity = _mapper.Map<Department>(DTO);

            await _unit.Departments.Add(Entity);
            await _unit.SaveChangesAsync();

            return Ok(DTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _unit.Departments.GetAllAsync();
            if(items is null)
                return NotFound("No departments found");


            var DTOs = _mapper.Map<List<DepartmentDTO>>(items);

            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _unit.Departments.GetByID(id);
            if (item is null)
                return NotFound("Department not found");

            var DTO = _mapper.Map<DepartmentDTO>(item);
            return Ok(DTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid client request");

            var item = await _unit.Departments.GetByID(id);
            if (item is null)
                return NotFound("Department not found");

            _mapper.Map(DTO, item);
            await _unit.SaveChangesAsync();
            return Ok(DTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var item = await _unit.Departments.GetByID(id);
            if (item is null)
                return NotFound("Department not found");

          
            var employees = await _unit.EmployeeRepo.GetByID(id);
            if (employees != null)
            {
                return BadRequest(new { message = "Cannot delete this department because it still has active employees. Please reassign or delete them first." });
            }

            await _unit.Departments.Delete(id);
            await _unit.SaveChangesAsync();

            return Ok(new { message = "Department deleted successfully" });
        }
    }
}
