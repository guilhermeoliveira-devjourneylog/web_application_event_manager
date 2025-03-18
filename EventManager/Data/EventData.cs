using EventManager.Models;

namespace EventManager.Data
{
    public class EventData
    {
        private readonly List<EventModel> Events = new()
        {
            new EventModel { Id = 1, Name = "Tech Conference 2025", Date = new DateTime(2025, 06, 20), Location = "São Paulo" },
            new EventModel { Id = 2, Name = "Startup Meetup", Date = new DateTime(2025, 07, 10), Location = "Rio de Janeiro" },
            new EventModel { Id = 3, Name = "AI & Robotics Expo", Date = new DateTime(2025, 08, 15), Location = "Lisbon" }
        };

        public List<EventModel> GetAllEvents()
        {
            return Events.ToList();
        }

        public Task<List<EventModel>> GetAllEventsAsync()
        {
            return Task.FromResult(Events.ToList());
        }

        public EventModel? GetEventById(int id)
        {
            return Events.FirstOrDefault(e => e.Id == id);
        }

        public Task<EventModel?> GetEventByIdAsync(int id)
        {
            var eventModel = Events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(eventModel);
        }
    }
}
