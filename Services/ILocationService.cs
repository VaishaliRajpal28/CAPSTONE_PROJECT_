using Capstone.Models;

namespace Capstone.Services
{
    public interface ILocationService
    {

        List<Location> Get();
       
        Location GetByID(string id);

        Task<Location> GetLatLongByLocation(string location);
    
    
    }
}
