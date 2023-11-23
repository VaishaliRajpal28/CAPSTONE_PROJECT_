using MongoDB.Driver;
using Capstone.Models;
using System.Web.Http;
using Capstone.Controllers;
using Microsoft.AspNetCore.Cors;

namespace Capstone.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMongoCollection<Location> _locations;
        public LocationService(ILocationStoreDatabaseSettings settings, IMongoClient mongoClient ) { 
          
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _locations = database.GetCollection<Location>(settings.LocationCollectionName);
        }

        
        


        public Location Create(Location location) { 
          
            _locations.InsertOne(location);
            return location;
        }

        public List<Location> Get() { 
        
        return _locations.Find(Location => true).ToList();
        }

        public Location GetByID(string id) { 
        
            return _locations.Find( Location => Location.Id == id).FirstOrDefault();
        
        }
        public async Task<Location> GetLatLongByLocation(string location)
        {
            var filter =  Builders<Location>.Filter.Eq(l => l.Name, location);
            var result =  await  _locations.Find(filter).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }

            else

            {

                throw new ArgumentException($"No location found for {location}");

            }
        }



    }
}
