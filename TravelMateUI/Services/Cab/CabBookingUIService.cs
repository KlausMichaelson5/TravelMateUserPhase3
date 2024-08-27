using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TravelMate.Models;
using TravelMateUI;


namespace TravelMate2.Services
{
    public interface ICabBookingUIService
    {
        Task AddCabBooking(CabBookingModel booking, int currentUserId);
        Task DeleteCabBooking(int id, int currentUserId);
        Task<List<CabBookingModel>> GetAllCabBookings(int currentUserId);
        Task<CabBookingModel> GetCabBookingById(int id, int currentUserId);
    }

    public class CabBookingUIService : ICabBookingUIService
    {
        private readonly HttpClient _httpClient;

        public CabBookingUIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Program.Configuration["CabBooking"]!);
        }

        public async Task<List<CabBookingModel>> GetAllCabBookings(int currentUserId)
        {
            return await _httpClient.GetFromJsonAsync<List<CabBookingModel>>($"?currentUserId={currentUserId}");
        }

        public async Task<CabBookingModel> GetCabBookingById(int id, int currentUserId)
        {
            var response = await _httpClient.GetAsync($"{id}?currentUserId={currentUserId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CabBookingModel>();
            }
            else
            {
                throw new Exception("Cab booking not found");
            }
        }

        public async Task AddCabBooking(CabBookingModel booking, int currentUserId)
        {
            await _httpClient.PostAsJsonAsync($"?currentUserId={currentUserId}", booking);
        }

        public async Task DeleteCabBooking(int id, int currentUserId)
        {
            await _httpClient.DeleteAsync($"{id}?currentUserId={currentUserId}");
        }
    }
}
