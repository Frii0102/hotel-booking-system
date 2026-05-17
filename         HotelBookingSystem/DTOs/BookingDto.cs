namespace HotelBookingSystem.DTOs;

public class BookingDto
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string Status { get; set; } = "Pending";
    public decimal TotalPrice { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}