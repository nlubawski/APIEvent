using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
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

        public ActionResult<List<EventReservation>> GetReservation()
        {
            return _eventReservationRepository.GetReservation();
        }

        public bool PostReservation(long idEvent, EventReservation eventReservation)
        {
            return _eventReservationRepository.PostReservation(idEvent, eventReservation);
        }

    }
}
