using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface IEventReservationService
    {
        ActionResult<List<EventReservation>> GetReservation();
        bool PostReservation(long idEvent, EventReservation eventReservation);



    }
}
