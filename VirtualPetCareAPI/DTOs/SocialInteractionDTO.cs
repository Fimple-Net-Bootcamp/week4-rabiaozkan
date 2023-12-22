namespace VirtualPetCareAPI.DTOs
{
    public class SocialInteractionDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime InteractionTime { get; set; }
        public int PetId1 { get; set; }
        public int PetId2 { get; set; }
    }
}
