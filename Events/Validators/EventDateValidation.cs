using System.ComponentModel.DataAnnotations;

namespace Events.Validators;

public class EventEndDateValidation : IValidatableObject
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate.HasValue && EndDate.HasValue && EndDate.Value < StartDate.Value)
        {
            yield return new ValidationResult(
                "End Date cannot be before Start Date.",
                new[] { nameof(EndDate) });
        }    }
}