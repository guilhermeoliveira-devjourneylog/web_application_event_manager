using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Event location is required")]
        public string Location { get; set; } = string.Empty;
    }
}
