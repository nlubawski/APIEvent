using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventRepository
    {
        Task<ActionResult<List<CityEvent>>> GetEventByTitleAsync(string title);
        Task<ActionResult<List<CityEvent>>> GetEventByLocalAndDateAsync(string local, string date);
        Task<ActionResult<List<CityEvent>>> GetEventByDateAndRangeAsync(string date, string initialPrice, string finalPrice);
        Task<bool> PostEventAsync(CityEventDTO cityEvent);
        Task<bool> CheckReservationAsync(long IdEvent);
        Task<bool> UpdateEventAsync(long id, CityEvent cityEvent);
        Task<bool> DeleteEventAsync(long id);
    }
}
