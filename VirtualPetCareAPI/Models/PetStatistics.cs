namespace VirtualPetCareAPI.Models
{
    public class PetStatistics
    {
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<HealthStatus> HealthStatuses { get; set; }
    }
}
