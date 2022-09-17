using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface IEventReservationService
    {
        Task<ActionResult<List<ReservationDTO>>> GetReservationAsync(string personName, string title);
        Task<bool> PostReservationAsync(EventReservationDTO eventReservation);
        Task<bool> DeleteReservationAsync(long IdReservation);
        Task<bool> UpdateQuantityReservationAsync(long IdReservation, long quantity);
    }
}
