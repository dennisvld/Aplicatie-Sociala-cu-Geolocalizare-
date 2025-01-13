using Microsoft.AspNetCore.Mvc;
using Platforma.API.DTOs;
using Platforma.API.Services;

namespace Platforma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetReviews(int locationId)
        {
            var reviews = await _reviewService.GetReviewsForLocationAsync(locationId);
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewDTO reviewDto)
        {
            var review = await _reviewService.AddReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetReviews), new { locationId = review.LocationId }, review);
        }
    }
}
