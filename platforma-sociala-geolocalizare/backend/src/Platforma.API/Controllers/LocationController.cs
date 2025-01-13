using Microsoft.AspNetCore.Mvc;
using Platforma.API.DTOs;
using Platforma.API.Services;

namespace Platforma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationDTO locationDto)
        {
            var location = await _locationService.AddLocationAsync(locationDto);
            return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
        }
    }
}
