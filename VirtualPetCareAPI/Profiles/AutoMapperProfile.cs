using AutoMapper;
using VirtualPetCareAPI.Models;
using VirtualPetCareAPI.DTOs;

namespace VirtualPetCareAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<Pet, PetDTO>();

            CreateMap<Activity, ActivityDTO>();

            CreateMap<Food, FoodDTO>();

            CreateMap<HealthStatus, HealthStatusDTO>();

            CreateMap<Training, TrainingDTO>();

            CreateMap<SocialInteraction, SocialInteractionDTO>();
        }
    }
}
