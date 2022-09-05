using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Service
{
    public class CityEventService : ICityEventService
    {
        //aqui preciso acessar a interface do banco 
        private readonly ICityEventRepository _cityEventRepository;

        public CityEventService(ICityEventRepository cityEventRepository)
        {
            _cityEventRepository = cityEventRepository;
        }
        public ActionResult<List<CityEvent>> GetEvent()
        {
            return _cityEventRepository.GetEvent();
        }
        public bool PostEvent(CityEvent cityEvent)
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
