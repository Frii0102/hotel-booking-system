using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (booking == null) return NotFound();
        return booking;
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> CreateBooking(BookingDto dto)
    {
        var booking = new Booking
        {
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckOut,
            Status = dto.Status,
            TotalPrice = dto.TotalPrice,
            UserId = dto.UserId,
            RoomId = dto.RoomId
        };
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, BookingDto dto)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return NotFound();
        booking.CheckIn = dto.CheckIn;
        booking.CheckOut = dto.CheckOut;
        booking.Status = dto.Status;
        booking.TotalPrice = dto.TotalPrice;
        booking.UserId = dto.UserId;
        booking.RoomId = dto.RoomId;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return NotFound();
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}