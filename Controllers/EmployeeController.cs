
using BLayers;
using DAccessLayers.Dto;
using DAccessLayers.Entities;
using DataAccessLayers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PLayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployeeService _employeeService;


        public EmployeeController(IEmployeeService employeeService)
        {

            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var EmployeeListDto = await _employeeService.GetAllAsync();
            return Ok(EmployeeListDto);
        }

        [HttpGet("{withoutMapper}")]

        public async Task<ActionResult> GetAllAsyncWithAutomapper()
        {
            var EmployeeListDto = await _employeeService.GetAllAsync();
            return Ok(EmployeeListDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            await _employeeService.AddAsync(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpateEmployeeAsyncIdAsync(int id, EmployeeDto dto)
        {
            try
            {
                await _employeeService.UpateEmployeeAsyncIdAsync(dto);
            }

            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(dto);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            var employeeToDelete = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }

            await _employeeService.DeleteByIdAsync(employeeToDelete);
            return NoContent();
        }
    }


}
    


