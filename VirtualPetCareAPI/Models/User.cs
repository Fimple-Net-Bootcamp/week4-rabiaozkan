using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
        public string Name { get; set; }
    }
}
