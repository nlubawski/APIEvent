using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventService
    {
        ActionResult<List<CityEvent>> GetEvent();
        ActionResult<List<CityEvent>> GetEventByTitle(string title);
        bool PostEvent(CityEvent cityEvent);
        public bool UpdateEvent(long id, CityEvent cityEvent);

        public bool DeleteEvent(long id);
    }
}
