using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
        private readonly ICityEventService _cityEventService;

        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> GetEvent()
        {
            return _cityEventService.GetEvent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> PostEvent(CityEvent cityEvent)
        {
            if(!_cityEventService.PostEvent(cityEvent))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Created),cityEvent);
        }
    }
}
