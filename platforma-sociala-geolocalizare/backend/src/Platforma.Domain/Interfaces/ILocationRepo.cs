using System.Collections.Generic;
using System.Threading.Tasks;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location> GetByIdAsync(int id);
    Task<Location> AddAsync(Location location);
}
