using FluentValidation;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Validators
{
    public class TrainingValidation : AbstractValidator<Training>
    {
        public TrainingValidation()
        {
            RuleFor(training => training.Name).NotEmpty().WithMessage("Training name is required.");
            RuleFor(training => training.PetId).GreaterThan(0).WithMessage("PetId must be greater than 0.");
        }
    }
}

