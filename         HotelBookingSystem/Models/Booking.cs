namespace HotelBookingSystem.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string Status { get; set; } = "Pending"; 
    public decimal TotalPrice { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
}