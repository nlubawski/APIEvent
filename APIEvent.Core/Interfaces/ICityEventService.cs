using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventService
    {
        ActionResult<List<CityEvent>> GetEvent();
        ActionResult<List<CityEvent>> GetEventByTitle(string title);

        ActionResult<List<CityEvent>> GetEventByLocalAndDate(string local, string date);

        ActionResult<List<CityEvent>> GetEventByDateAndRange(string date, string initialPrice, string finalPrice);

        bool PostEvent(CityEventDTO cityEvent);
        public bool UpdateEvent(long id, CityEvent cityEvent);

        public bool DeleteEvent(long id);
    }
}
