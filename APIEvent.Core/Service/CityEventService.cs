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
        public async Task<ActionResult<List<CityEvent>>> GetEventByTitleAsync(string title)
        {
            return await _cityEventRepository.GetEventByTitleAsync(title);
        }
        public async Task<ActionResult<List<CityEvent>>> GetEventByLocalAndDateAsync(string local, string date)
        {
            return await _cityEventRepository.GetEventByLocalAndDateAsync(local, date);
        }
        public async Task<ActionResult<List<CityEvent>>> GetEventByDateAndRangeAsync(string date, string initialPrice, string finalPrice)
        {
            return await _cityEventRepository.GetEventByDateAndRangeAsync(date, initialPrice, finalPrice);
        }
        public async Task<bool> PostEventAsync(CityEventDTO cityEvent)
        {
            return await _cityEventRepository.PostEventAsync(cityEvent);
        }
        public async Task<bool> UpdateEventAsync(long id, CityEvent cityEvent)
        {
            return await _cityEventRepository.UpdateEventAsync(id, cityEvent);
        }
        public async Task<bool> DeleteEventAsync(long id)
        {
            return await _cityEventRepository.DeleteEventAsync(id);
        }
    }
}
