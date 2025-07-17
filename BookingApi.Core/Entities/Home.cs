namespace BookingApi.Core.Entities
{
    public class Home
    {
        public string? HomeId { get; set; }
        public string? HomeName { get; set; }
        public HashSet<DateTime> AvailableSlots { get; set; } = new HashSet<DateTime>();
    }
}
