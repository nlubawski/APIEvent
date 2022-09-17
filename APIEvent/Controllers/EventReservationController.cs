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
    [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
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
        public async Task<ActionResult<List<ReservationDTO>>> GetReservationAsync(string personName, string title)
        {
            return await _eventReservationService.GetReservationAsync(personName, title);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin, cliente")]
        public async Task<ActionResult<CityEvent>> PostReservationAsync([FromBody] EventReservationDTO eventReservation)
        {
            if (!( await _eventReservationService.PostReservationAsync(eventReservation)))
            {
                return BadRequest();
            }
            return Ok(eventReservation);
        }

        [HttpPatch("/reservations/{idReservation}/{quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CityEvent>> UpdateQuantityReservationAsync(long idReservation, long quantity)
        {
            if (! (await _eventReservationService.UpdateQuantityReservationAsync(idReservation, quantity)))
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteReservationAsync(long idReservation)
        {
            if (! (await _eventReservationService.DeleteReservationAsync(idReservation)))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
