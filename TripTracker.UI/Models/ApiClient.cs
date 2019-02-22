using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.Models;
using TripTracker.UI.Services;

namespace TripTracker.UI.Models
{
    public class ApiClient : IApiClient
    {
        public  readonly HttpClient _httpClient;
        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Trip> GetTripAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Trips/{id}");
            response.EnsureSuccessStatusCode();

            
            return await response.Content.ReadAsJsonAsync<Trip>();
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Trips");
            response.EnsureSuccessStatusCode();

            ///Newtonsoft.json package
            return await response.Content.ReadAsJsonAsync<List<Trip>>();
        }

        public async Task PutTripAsync(Trip tripToUpdate)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Trips/{tripToUpdate.Id}",tripToUpdate);
            response.EnsureSuccessStatusCode();
        }

        public async Task TripToAddAsync(Trip tripToAdd)
        {
            var respone = await _httpClient.PostAsJsonAsync("/api/Trips", tripToAdd);
            respone.EnsureSuccessStatusCode();

        }
    }
}