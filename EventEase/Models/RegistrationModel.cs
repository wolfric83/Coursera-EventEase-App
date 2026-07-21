using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Attendee name is required.")]
        [StringLength(100, ErrorMessage = "Attendee name must be 100 characters or fewer.")]
        public string AttendeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        public EventModel SelectedEvent { get; set; } = new EventModel();

        public bool IsAttending { get; set; }
    }
}
