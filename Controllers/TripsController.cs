using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTracker.Data;
using TripTracker.Models;

namespace TripTracker.Controllers{

     [Route("api/[controller]")]   
    public class TripsController :ControllerBase
    {

        private TripContext _context;

        public TripsController (TripContext context)
        {
            _context = context;
        }

        // GET api/trips
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
           var trips = await _context.Trips
                .AsNoTracking()
                .ToListAsync();
           return Ok(trips);
        }

        // GET api/trips/5
        [HttpGet("{id}")]
       // public async Task<Trip> GetAsync(int id)
       public Trip Get(int id)
        {
            // var trip = await _context.Trips            
            // .FindAsync(id);

            // return trip;
            return _context.Trips.Find(id);
        }

        // POST api/trips
        [HttpPost]
        //more like add
        public IActionResult Post([FromBody] Trip value)
        {
            //checkin
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Add(value);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/trips/5
        [HttpPut("{id}")]
        //more like update
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trip value)
        {
            if(!_context.Trips.Any( x => x.Id == id))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Update(value);
            await _context.SaveChangesAsync();

             return Ok();
        }

        // DELETE api/trips/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = _context.Trips.Find(id);
             if(myTrip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(myTrip);
            _context.SaveChanges();
            return NoContent();
        }
    }
}