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
    }
}
