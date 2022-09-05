namespace APIEvent.Core.Model
{
    public class EventReservation
    {
        //public EventReservation(long idEvent, string personName, long quantity)
        //{
        //    IdEvent = idEvent;
        //    PersonName = personName;
        //    Quantity = quantity;
        //}

     public long IdEvent { get; set; }
     public long IdReservation { get; set; }
     public string PersonName { get; set; }
     public long Quantity { get; set; }

    }
}
