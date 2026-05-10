namespace HotelBookingSystem.Models;
public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
