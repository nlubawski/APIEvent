using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityEventController : ControllerBase
    {
        private readonly ICityEventService _cityEventService;

        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet]
        public ActionResult<List<CityEvent>> GetEvent()
        {
            return _cityEventService.GetEvent();
        }

        [HttpPost]
        public ActionResult<CityEvent> PostEvent(CityEvent cityEvent)
        {
            if(!_cityEventService.PostEvent(cityEvent))
            {
                return BadRequest();
            }
            return Ok(cityEvent);

        }
    }
}
