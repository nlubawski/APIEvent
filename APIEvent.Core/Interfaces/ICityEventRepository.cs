using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventRepository
    {
        ActionResult<List<CityEvent>> GetEvent();

        ActionResult<List<CityEvent>> GetEventByTitle(string title);

        ActionResult<List<CityEvent>> GetEventByLocalAndDate(string local, string date);

        ActionResult<List<CityEvent>> GetEventByDateAndRange(string date, string initialPrice, string finalPrice);

        public bool PostEvent(CityEvent cityEvent);

        public bool CheckReservation(long IdEvent);

        bool UpdateEvent(long id, CityEvent cityEvent);

        bool DeleteEvent(long id);



    }
}
