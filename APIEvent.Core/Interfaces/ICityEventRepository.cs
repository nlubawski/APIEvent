using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventRepository
    {
        ActionResult<List<CityEvent>> GetEvent();

        public bool PostEvent(CityEvent cityEvent);

        bool UpdateEvent(long id, CityEvent cityEvent);


    }
}
