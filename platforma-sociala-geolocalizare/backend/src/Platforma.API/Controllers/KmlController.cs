// File: src/Platforma.API/Controllers/KmlController.cs

using Microsoft.AspNetCore.Mvc;
using Platforma.API.Services;

[Route("api/[controller]")]
[ApiController]
public class KmlController : ControllerBase
{
    private readonly KmlService _kmlService;

    public KmlController(KmlService kmlService)
    {
        _kmlService = kmlService;
    }

    // GET: api/kml
    [HttpGet]
    public IActionResult GetKmlData()
    {
        var geoJson = _kmlService.ParseKmlToGeoJson("path/to/your/file.kml");
        if (string.IsNullOrEmpty(geoJson))
        {
            return NotFound("No KML data found.");
        }
        return Content(geoJson, "application/json");
    }
}
