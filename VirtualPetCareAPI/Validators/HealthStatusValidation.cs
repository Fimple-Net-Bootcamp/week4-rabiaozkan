using FluentValidation;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Validators
{
    public class HealthStatusValidation : AbstractValidator<HealthStatus>
    {
        public HealthStatusValidation()
        {
            RuleFor(status => status.Status).NotEmpty().WithMessage("Health status is required.");
            RuleFor(status => status.PetId).GreaterThan(0).WithMessage("PetId must be greater than 0.");
        }
    }
}
