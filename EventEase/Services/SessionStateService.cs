using EventEase.Models;

namespace EventEase.Services
{
    public class SessionStateService
    {
        public string AttendeeName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public EventModel SelectedEvent { get; private set; } = new EventModel();
        // Store a session-scoped list of events so edits persist across pages
        public List<EventModel> Events { get; } = new List<EventModel>();
        public bool IsRegistered { get; private set; }
        public bool IsAttending { get; private set; }

        public void SaveRegistration(string attendeeName, string email, EventModel selectedEvent)
        {
            AttendeeName = attendeeName;
            Email = email;
            SelectedEvent = selectedEvent;
            IsRegistered = true;
            IsAttending = true;
        }

        public void SetSelectedEvent(EventModel selectedEvent)
        {
            SelectedEvent = selectedEvent;
            // If the selected event is not already in the session list, add it so it can be edited
            if (!Events.Contains(selectedEvent))
            {
                Events.Add(selectedEvent);
            }
        }

        public void AddEvent(EventModel newEvent)
        {
            Events.Add(newEvent);
        }

        public void UpdateAttendance(bool isAttending)
        {
            if (!IsRegistered)
            {
                return;
            }

            IsAttending = isAttending;
        }

        public void ClearSession()
        {
            AttendeeName = string.Empty;
            Email = string.Empty;
            SelectedEvent = new EventModel();
            IsRegistered = false;
            IsAttending = false;
        }
    }
}
