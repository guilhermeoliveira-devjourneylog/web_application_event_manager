namespace EventManager.Services
{
    public class AttendanceService
    {
        private readonly Dictionary<int, List<string>> _attendance = new();

        public Task MarkAttendanceAsync(int eventId, string userName)
        {
            if (!_attendance.ContainsKey(eventId))
            {
                _attendance[eventId] = new List<string>();
            }

            _attendance[eventId].Add(userName);
            return Task.CompletedTask;
        }

        public Task<List<string>> GetAttendanceAsync(int eventId)
        {
            return Task.FromResult(_attendance.TryGetValue(eventId, out var attendees) ? attendees : new List<string>());
        }
    }
}
