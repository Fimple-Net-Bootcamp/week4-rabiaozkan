using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Models
{
    public class HealthStatus
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
