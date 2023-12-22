namespace VirtualPetCareAPI.DTOs
{
    public class HealthStatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int PetId { get; set; }
    }
}
