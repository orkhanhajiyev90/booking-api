namespace BookingApi.Core.Models.Response
{
    public class AvailableHomeResponse
    {
        public string? HomeId { get; set; }
        public string? HomeName { get; set; }
        public List<DateTime> AvailableSlots { get; set; } = new List<DateTime>();
    }
}
