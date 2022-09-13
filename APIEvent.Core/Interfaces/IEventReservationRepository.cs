using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface IEventReservationRepository
    {
        ActionResult<List<ReservationDTO>> GetReservation(string personName, string title);

        bool PostReservation(long idEvent, EventReservation eventReservation);

        bool DeleteReservation(long idReservation);

        bool UpdateQuantityReservation(long idReservation, long quantity);

    }
}
