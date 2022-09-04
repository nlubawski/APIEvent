using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Interfaces
{
    public interface ICityEventRepository
    {
        ActionResult<List<CityEvent>> GetEvent();
    }
}
