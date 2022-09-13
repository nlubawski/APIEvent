using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface IEventReservationService
    {
        ActionResult<List<ReservationDTO>> GetReservation(string personName, string title);
        bool PostReservation(long idEvent, EventReservation eventReservation);



    }
}
