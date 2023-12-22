using FluentValidation;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Validators
{
    public class ActivityValidation : AbstractValidator<Activity>
    {
        public ActivityValidation()
        {
            RuleFor(activity => activity.Name).NotEmpty().WithMessage("Activity name is required.");
            RuleFor(activity => activity.PetId).GreaterThan(0).WithMessage("PetId must be greater than 0.");
        }
    }
}
