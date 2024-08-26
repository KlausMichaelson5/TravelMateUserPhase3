using System.Net.Http.Json;
using TravelMate.Models;
namespace TravelMateUI.Services
{
    public interface ISearchUIService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<List<Cab>> GetAllCabs();
    }

    public class SearchUIService : ISearchUIService
    {
        private readonly HttpClient _httpClient;

        public SearchUIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5182/api/");
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _httpClient.GetFromJsonAsync<List<Hotel>>("search/hotels");
        }

        public async Task<List<Cab>> GetAllCabs()
        {
            return await _httpClient.GetFromJsonAsync<List<Cab>>("search/cabs");
        }
    }
}
