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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;


        public SkillController(ISkillService skillService)
        {

            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetAllAsync()
        {
            var employee = await _skillService.GetAll();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(SkillDto skill)
        {
            if (skill == null)
            {
                return BadRequest();
            }

            await _skillService.Add(skill);
            return Ok(skill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkillAsync(int id, SkillDto skill)
        {
            await _skillService.Upate(skill);   
            return Ok(skill);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var employee = await _skillService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            var employeeToDelete = await _skillService.GetById(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }

            await _skillService.Delete(employeeToDelete);
            return NoContent();
        }
    }


}

