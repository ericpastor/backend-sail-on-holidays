using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController<T, TReadDTO, TCreateDTO, TUpdateDTO> : ControllerBase
        where T : BaseEntity
    {
        private readonly IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> _service;
        public BaseController(IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> service)
        {
            _service = service;
        }

        [HttpGet()]
        public virtual async Task<ActionResult<IEnumerable<TReadDTO>>> GetAllAsync([FromQuery] GetAllParams parameters)
        {
            return Ok(await _service.GetAllAsync(parameters));
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<ActionResult<TReadDTO>> GetByIdAsync(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<TReadDTO>> CreateOneAsync([FromBody] TCreateDTO createObject)
        {
            var createdObject = await _service.CreateOneAsync(createObject);
            return CreatedAtAction(nameof(CreateOneAsync), createdObject);
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            return Ok(await _service.DeleteOneAsync(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:guid}")]
        public virtual async Task<ActionResult<TReadDTO>> UpdateOneAsync([FromRoute] Guid id, [FromBody] TUpdateDTO updateDTO)
        {
            return Ok(await _service.UpdateOneAsync(id, updateDTO));
        }
    }
}