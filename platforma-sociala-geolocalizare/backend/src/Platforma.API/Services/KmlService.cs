// File: src/Platforma.API/Services/KmlService.cs

using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System.IO;
using System.Text.Json;

public class KmlService
{
    public string ParseKmlToGeoJson(string kmlFilePath)
    {
        // Read the KML file
        var fileContent = File.ReadAllText(kmlFilePath);
        var parser = new Parser();
        parser.ParseString(fileContent, false);

        // Get the KML root
        var kml = parser.Root as Kml;
        if (kml?.Feature == null) return null;

        // Convert to GeoJSON
        var placemarks = new List<object>();
        foreach (var feature in kml.Flatten())
        {
            if (feature is Placemark placemark)
            {
                placemarks.Add(new
                {
                    Name = placemark.Name,
                    Coordinates = placemark.Geometry
                });
            }
        }

        return JsonSerializer.Serialize(placemarks);
    }
}
