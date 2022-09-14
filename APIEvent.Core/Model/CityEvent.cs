using System.ComponentModel.DataAnnotations;

namespace APIEvent.Core.Model
{
    public class CityEvent
    {
        
        public long IdEvent {get; set;}

        [Required(ErrorMessage = "Título é obrigatório")]
        [MaxLength(100, ErrorMessage = "O título pode ter até 100 caracteres")]
        [MinLength(3, ErrorMessage = "O título deve ter mais que 2 caracteres")]
        public string Title {get; set;} 
        
        public string? Description { get; set; }

        [Required(ErrorMessage = "Data do evento é obrigatória")]
        public DateTime DateHourEvent { get; set; }

        [Required(ErrorMessage = "Local é obrigatório")]
        [MaxLength(100, ErrorMessage = "O local pode ter até 100 caracteres")]
        [MinLength(3, ErrorMessage = "O local deve ter mais que 2 caracteres")]
        public string Local { get; set; }      

        public string? Address { get; set; }

        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public bool Status { get; set; }
    }
}
