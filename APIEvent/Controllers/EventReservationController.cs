using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventReservationController : ControllerBase
    {
        readonly IEventReservationService _eventReservation;

        public EventReservationController(IEventReservationService eventReservation)
        {
            _eventReservation = eventReservation;
        }

        [HttpGet]
        public ActionResult<List<EventReservation>>  GetReservation()
        {
            return _eventReservation.GetReservation();
        }
    }
}
