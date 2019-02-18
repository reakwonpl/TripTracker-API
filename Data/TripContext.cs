using Microsoft.EntityFrameworkCore;
using TripTracker.Models;

namespace TripTracker.Data
{
    public class TripContext: DbContext
    {
        public DbSet<Trip> Trips { get; set; }
       
        
    }
}