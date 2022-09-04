namespace APIEvent.Core.Model
{
    public class CityEvent
    {
        public CityEvent(string title, string local, DateTime dateHourEvent, string? description = null, string? address = null, decimal? preco = null)
        {
            Title = title;
            Local = local;
            DateHourEvent = dateHourEvent;
            Description = description;           
            Address = address;
            Preco = preco;
        }

        public long IdEvent {get; set;}

        public string Title {get; set;} 
        
        public string? Description { get; set; }

        public DateTime DateHourEvent { get; set; }
        
        public string Local { get; set; }      

        public string? Address { get; set; }

        public decimal? Preco { get; set; } 
    }
}
