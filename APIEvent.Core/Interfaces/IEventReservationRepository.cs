using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface IEventReservationRepository
    {
        ActionResult<List<EventReservation>> GetReservation();
    }
}
