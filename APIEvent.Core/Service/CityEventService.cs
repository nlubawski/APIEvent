using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Service
{
    public class CityEventService : ICityEventService
    {

        private readonly ICityEventRepository _cityEventRepository;

        public CityEventService(ICityEventRepository cityEventRepository)
        {
            _cityEventRepository = cityEventRepository;
        }
        public ActionResult<List<CityEvent>> GetEvent()
        {
            return _cityEventRepository.GetEvent();
        }

        public ActionResult<List<CityEvent>> GetEventByTitle(string title)
        {
            return _cityEventRepository.GetEventByTitle(title);
        }

        public ActionResult<List<CityEvent>> GetEventByLocalAndDate(string local, string date)
        {
            return _cityEventRepository.GetEventByLocalAndDate(local, date);
        }

        public ActionResult<List<CityEvent>> GetEventByDateAndRange(string date, string initialPrice, string finalPrice)
        {
            return _cityEventRepository.GetEventByDateAndRange(date, initialPrice, finalPrice);
        }

        public bool PostEvent(CityEventDTO cityEvent)
        {
            return _cityEventRepository.PostEvent(cityEvent);
        }
        public bool UpdateEvent(long id, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateEvent(id, cityEvent);
        }
        public bool DeleteEvent(long id)
        {
            return _cityEventRepository.DeleteEvent(id);
        }

    }
}
