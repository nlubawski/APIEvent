using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIEvent.Core.Service
{
    public class EventReservationService : IEventReservationService
    {
        private readonly IEventReservationRepository _eventReservationRepository;

        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }

        public async Task<ActionResult<List<ReservationDTO>>> GetReservationAsync(string personName, string title)
        {
            return await _eventReservationRepository.GetReservationAsync(personName, title);
        }

        public async Task<bool> PostReservationAsync(EventReservationDTO eventReservation)
        {
            return await _eventReservationRepository.PostReservationAsync(eventReservation);
        }

        public async Task<bool> UpdateQuantityReservationAsync(long IdReservation, long quantity)
        {
            return await _eventReservationRepository.UpdateQuantityReservationAsync(IdReservation, quantity);
        }

        public async Task<bool> DeleteReservationAsync(long IdReservation)
        {
            return await _eventReservationRepository.DeleteReservationAsync(IdReservation);
        }

    }
}
