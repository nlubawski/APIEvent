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

        [HttpGet("/events")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> GetEvent()
        {
            return _cityEventService.GetEvent();
        }

        [HttpGet("/events{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> GetEventByTitle(string title)
        {
            return _cityEventService.GetEventByTitle(title);
        }

        //TO FEATIX - pegar evento por local e data


        //TO FEATIX - pegar por range de preço e data



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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEvent(long id, CityEvent cityEvent)
        {
            if(!_cityEventService.UpdateEvent(id, cityEvent))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        //TO FIX
        //Se não possuir reservar ok, se tiver tem que por como inativo
        public IActionResult DeleteEvent(long id)
        {
            if (!_cityEventService.DeleteEvent(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
