using System.Collections.Generic;
using System.Threading.Tasks;
using TripTracker.Models;

namespace TripTracker.UI.Services
{
    public interface IApiClient
    {
         Task<List<Trip>> GetTripsAsync();
         Task<Trip> GetTripAsync(int id);
         Task PutTripAsync(Trip tripToUpdate);
         Task TripToAddAsync(Trip tripToAdd);
         

         
    }
}