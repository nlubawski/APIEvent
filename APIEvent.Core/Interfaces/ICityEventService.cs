using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventService
    {
        ActionResult<List<CityEvent>> GetEvent();
    }
}
