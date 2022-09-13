using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using APIEvent.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        readonly IEventReservationService _eventReservationService;

        public EventReservationController(IEventReservationService eventReservation)
        {
            _eventReservationService = eventReservation;
        }

        [HttpGet("/reservations/{title}/{personName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ReservationDTO>>  GetReservation(string personName, string title)
        {
            return _eventReservationService.GetReservation(personName, title);
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> PostReservation(long idEvent, EventReservation eventReservation)
        {
            if (!_eventReservationService.PostReservation(idEvent, eventReservation))
            {
                return BadRequest();
            }
            //return CreatedAtAction(nameof(Created), eventReservation);
            return Ok(eventReservation);
        }



    }
}
