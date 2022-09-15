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
    public class EventReservationController : ControllerBase
    {
        readonly IEventReservationService _eventReservationService;

        public EventReservationController(IEventReservationService eventReservation)
        {
            _eventReservationService = eventReservation;
        }

        [HttpGet("/reservations/{title}/{personName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin, cliente")]
        public ActionResult<List<ReservationDTO>>  GetReservation(string personName, string title)
        {
            return _eventReservationService.GetReservation(personName, title);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin, cliente")]
        public ActionResult<CityEvent> PostReservation([FromBody] EventReservationDTO eventReservation)
        {
            if (!_eventReservationService.PostReservation(eventReservation))
            {
                return BadRequest();
            }
            return Ok(eventReservation);
        }

        [HttpPatch("/reservations/{idReservation}/{quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin")]
        public ActionResult<CityEvent> UpdateQuantityReservation(long idReservation, long quantity)
        {
            if (!_eventReservationService.UpdateQuantityReservation(idReservation, quantity))
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteReservation(long idReservation)
        {
            if (!_eventReservationService.DeleteReservation(idReservation))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
