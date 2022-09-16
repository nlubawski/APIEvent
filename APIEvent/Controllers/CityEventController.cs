using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APIEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]

    public class CityEventController : ControllerBase
    {
        private readonly ICityEventService _cityEventService;

        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet("/events")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<CityEvent>>> GetEventAsync()
        {
            return await _cityEventService.GetEventAsync();
        }

        [HttpGet("/events/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin, cliente")]
        public async Task<ActionResult<List<CityEvent>>> GetEventByTitleAsync(string title)
        {
            return await _cityEventService.GetEventByTitleAsync(title);
        }

        [HttpGet("/events/{local}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin, cliente")]
        public async Task<ActionResult<List<CityEvent>>> GetEventByLocalAndDateAsync(string local, string date)
        {
            return await _cityEventService.GetEventByLocalAndDateAsync(local, date);
        }

        [HttpGet("/events/{date}/{initialPrice}/{finalPrice}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,cliente")]
        public async Task<ActionResult<List<CityEvent>>> GetEventByDateAndRangeAsync(string date, string initialPrice, string finalPrice)
        {
            return await _cityEventService.GetEventByDateAndRangeAsync(date, initialPrice, finalPrice);
        }

        [HttpPost("/events")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CityEvent>> PostEventAsync([FromBody] CityEventDTO cityEvent)
        {
            if(!( await _cityEventService.PostEventAsync(cityEvent)))
            {
                return BadRequest();
            }
            return Ok(cityEvent);
        }

        [HttpPut("/events")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateEventAsync(long id, CityEvent cityEvent)
        {
            if(!(await _cityEventService.UpdateEventAsync(id, cityEvent)))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/events")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteEventAsync(long id)
        {
            if (!(await _cityEventService.DeleteEventAsync(id)))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
