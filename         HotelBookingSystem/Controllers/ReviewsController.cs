using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReviewsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
    {
        return await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Room)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
        var review = await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (review == null) return NotFound();
        return review;
    }

    [HttpPost]
    public async Task<ActionResult<Review>> CreateReview(ReviewDto dto)
    {
        var review = new Review
        {
            Comment = dto.Comment,
            Rating = dto.Rating,
            UserId = dto.UserId,
            RoomId = dto.RoomId
        };
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(int id, ReviewDto dto)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return NotFound();
        review.Comment = dto.Comment;
        review.Rating = dto.Rating;
        review.UserId = dto.UserId;
        review.RoomId = dto.RoomId;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return NotFound();
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}