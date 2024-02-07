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

        public virtual async Task<ActionResult<TReadDTO>> GetByIdAsync(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost()]
        public virtual async Task<ActionResult<TReadDTO>> CreateOneAsync([FromBody] TCreateDTO createObject)
        {
            return CreatedAtAction(nameof(CreateOneAsync), await _service.CreateOneAsync(createObject));
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            return Ok(await _service.DeleteOneAsync(id));
        }

        [HttpPatch("{id:guid}")]
        public virtual async Task<ActionResult<TReadDTO>> UpdateOneAsync([FromRoute] Guid id, [FromBody] TUpdateDTO updateDTO)
        {
            return Ok(await _service.UpdateOneAsync(id, updateDTO));
        }

    }
}