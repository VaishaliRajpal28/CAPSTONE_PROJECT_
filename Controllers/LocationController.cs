using Capstone.Models;
using Capstone.Services;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    
    // Allow CORS for all origins. (Caution!)
   
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;
        // GET: api/<LocationController>


        public LocationController(ILocationService locationService) { 
        
        this.locationService = locationService;
        
        }
        [HttpGet]
        public ActionResult<List<Location>> Get()
        {
            return locationService.Get();
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public ActionResult<Location> GetByID(string id)
        {
            var location = locationService.GetByID(id);

            if (location == null) {
                return NotFound($"location with Id = {id} not found");
                    
                    
            }

            return location;


        }

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet("location/{location}")]
        public async Task<ActionResult<Location>> GetLatLongByLocationAsync(string location)
        {
            try
            {
                var result =  await locationService.GetLatLongByLocation(location);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

