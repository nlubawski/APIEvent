
namespace APIEvent.Core.Model.DTO
{
    public class ReservationDTO
    {
        public long IdEvent { get; set; }
        public long IdReservation { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateHourEvent { get; set; }
        public string Local { get; set; }
        public string? Address { get; set; }
        public string PersonName { get; set; }
        public long Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
