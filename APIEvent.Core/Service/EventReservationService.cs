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

        public ActionResult<List<ReservationDTO>> GetReservation(string personName, string title)
        {
            return _eventReservationRepository.GetReservation(personName, title);
        }

        public bool PostReservation(long idEvent, EventReservation eventReservation)
        {
            return _eventReservationRepository.PostReservation(idEvent, eventReservation);
        }


        public bool DeleteReservation(long IdReservation)
        {
            return _eventReservationRepository.DeleteReservation(IdReservation);
        }
    }
}
