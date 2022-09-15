using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<CityEvent>> GetEvent()
        {
            return _cityEventService.GetEvent();
        }

        [HttpGet("/events/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin, cliente")]
        public ActionResult<List<CityEvent>> GetEventByTitle(string title)
        {
            return _cityEventService.GetEventByTitle(title);
        }

        [HttpGet("/events/{local}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin, cliente")]
        public ActionResult<List<CityEvent>> GetEventByLocalAndDate(string local, string date)
        {
            return _cityEventService.GetEventByLocalAndDate(local, date);
        }

        [HttpGet("/events/{date}/{initialPrice}/{finalPrice}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,cliente")]
        public ActionResult<List<CityEvent>> GetEventByDateAndRange(string date, string initialPrice, string finalPrice)
        {
            return _cityEventService.GetEventByDateAndRange(date, initialPrice, finalPrice);
        }

        [HttpPost("/events")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin")]
        public ActionResult<CityEvent> PostEvent([FromBody] CityEventDTO cityEvent)
        {
            if(!_cityEventService.PostEvent(cityEvent))
            {
                return BadRequest();
            }
            return Ok(cityEvent);
        }

        [HttpPut("/events")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateEvent(long id, CityEvent cityEvent)
        {
            if(!_cityEventService.UpdateEvent(id, cityEvent))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/events")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteEvent(long id)
        {
            if (!_cityEventService.DeleteEvent(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
