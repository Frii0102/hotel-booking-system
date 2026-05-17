using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await _context.Services.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();
        return service;
    }

    [HttpPost]
    public async Task<ActionResult<Service>> CreateService(ServiceDto dto)
    {
        var service = new Service
        {
            Name = dto.Name,
            Price = dto.Price
        };
        _context.Services.Add(service);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, ServiceDto dto)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();
        service.Name = dto.Name;
        service.Price = dto.Price;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}