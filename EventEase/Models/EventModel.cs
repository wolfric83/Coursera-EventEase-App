using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class EventModel : IValidatableObject
    {
        public EventModel()
        {
            Date = DateTime.Today;
        }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(200, ErrorMessage = "Event name must be 200 characters or fewer.")]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location must be 200 characters or fewer.")]
        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date == default(DateTime))
            {
                yield return new ValidationResult("Event date is required.", new[] { nameof(Date) });
            }
        }
    }
}
