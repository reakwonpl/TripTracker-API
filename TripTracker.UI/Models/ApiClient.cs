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
    }
}