
using System.ComponentModel.DataAnnotations;

namespace APIEvent.Core.Model.DTO
{
    public class EventReservationDTO
    {

        [Required(ErrorMessage = "Id do evento é obrigatório")]
        public long IdEvent { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome pode ter até 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter mais que 2 caracteres")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        public long Quantity { get; set; }
    }
}
