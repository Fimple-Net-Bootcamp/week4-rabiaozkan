using FluentValidation;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Validators
{
    public class PetValidation : AbstractValidator<Pet>
    {
        public PetValidation()
        {
            RuleFor(pet => pet.Name).NotEmpty().WithMessage("Pet name is required.");
            RuleFor(pet => pet.UserId).GreaterThan(0).WithMessage("User ID must be a positive number.");
        }
    }
}
