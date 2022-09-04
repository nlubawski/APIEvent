using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface IEventReservationService
    {
        public ActionResult<List<EventReservation>> GetReservation();

    }
}
