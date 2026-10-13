using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequirementAPI.DTOs;
using RequirementAPI.Models;
using RequirementAPI.Services.Interfaces;

namespace RequirementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : ControllerBase
    {
        private readonly IRequirementService _service;

        public RequirementsController(IRequirementService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all Requirements.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<RequirementResponseDto>>> GetAll()
        {
            var requirements = await _service.GetAllAsync();

            return Ok(requirements);
        }

        /// <summary>
        /// Retrieves a Requirement by its ID.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RequirementResponseDto>> GetById(int id)
        {
            var requirement = await _service.GetByIdAsync(id);

            if (requirement is null)
            {
                return NotFound(new
                {
                    message = $"Requirement with ID {id} was not found."
                });
            }

            return Ok(requirement);
        }

        /// <summary>
        /// Creates a new Requirement.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<RequirementResponseDto>> Create(CreateRequirementDto dto)
        {
            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
