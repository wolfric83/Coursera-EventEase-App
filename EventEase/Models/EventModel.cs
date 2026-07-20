using System;

namespace EventEase.Models
{
    public class EventModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
