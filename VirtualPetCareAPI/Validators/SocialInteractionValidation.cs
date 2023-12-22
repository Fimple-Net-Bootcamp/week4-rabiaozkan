using FluentValidation;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Validators
{
    public class SocialInteractionValidation : AbstractValidator<SocialInteraction>
    {
        public SocialInteractionValidation()
        {
            RuleFor(interaction => interaction.Type).NotEmpty().WithMessage("Interaction type is required.");
            RuleFor(interaction => interaction.PetId1).GreaterThan(0).WithMessage("PetId1 must be greater than 0.");
        }
    }
}

