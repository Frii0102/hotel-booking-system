namespace HotelBookingSystem.DTOs;

public class RoomDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
}