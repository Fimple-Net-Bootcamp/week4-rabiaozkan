using FluentValidation;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Validators
{
    public class FoodValidation : AbstractValidator<Food>
    {
        public FoodValidation()
        {
            RuleFor(food => food.Name).NotEmpty().WithMessage("Food name is required.");
            RuleFor(food => food.PetId).GreaterThan(0).WithMessage("PetId must be greater than 0.");
        }
    }
}

