using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório")]
        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O local do evento é obrigatório")]
        public string Location { get; set; } = string.Empty;
    }

}
