public interface ILocationService
{
    Task<IEnumerable<Location>> GetAllLocationsAsync();
    Task<Location> GetLocationByIdAsync(int id);
    Task<Location> AddLocationAsync(LocationDTO locationDto);
}

public class LocationService : ILocationService
{
    private readonly ILocationRepository _repository;

    public LocationService(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync() => await _repository.GetAllAsync();
    public async Task<Location> GetLocationByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task<Location> AddLocationAsync(LocationDTO locationDto)
    {
        var location = new Location
        {
            Name = locationDto.Name,
            Description = locationDto.Description,
            Latitude = locationDto.Latitude,
            Longitude = locationDto.Longitude
        };
        return await _repository.AddAsync(location);
    }
}
