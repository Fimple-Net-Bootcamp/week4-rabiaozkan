namespace VirtualPetCareAPI.Models
{
    public class SocialInteraction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime InteractionTime { get; set; }


        public int PetId1 { get; set; }
        public Pet Pet1 { get; set; }
        public int PetId2 { get; set; }
        public Pet Pet2 { get; set; }
    }
}

