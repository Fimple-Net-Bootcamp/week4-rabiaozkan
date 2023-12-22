using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Activity name length can't be more than 100 characters.")]
        public string Name { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
