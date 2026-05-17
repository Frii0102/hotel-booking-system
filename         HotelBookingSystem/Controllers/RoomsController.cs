using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        return await _context.Rooms.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();
        return room;
    }

    [HttpPost]
    public async Task<ActionResult<Room>> CreateRoom(RoomDto dto)
    {
        var room = new Room
        {
            Name = dto.Name,
            Type = dto.Type,
            PricePerNight = dto.PricePerNight,
            Description = dto.Description,
            IsAvailable = dto.IsAvailable
        };
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, RoomDto dto)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();
        room.Name = dto.Name;
        room.Type = dto.Type;
        room.PricePerNight = dto.PricePerNight;
        room.Description = dto.Description;
        room.IsAvailable = dto.IsAvailable;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}