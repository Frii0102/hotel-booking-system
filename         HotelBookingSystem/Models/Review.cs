namespace HotelBookingSystem.Models;

public class Review
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; } // 1-5
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
}