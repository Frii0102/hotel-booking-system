namespace HotelBookingSystem.DTOs;

public class ReviewDto
{
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}