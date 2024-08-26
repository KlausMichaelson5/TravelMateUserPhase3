﻿using System.Net.Http.Json;
using System.Threading.Tasks;
using TravelMate.Models;

namespace TravelMate.Services
{
    public interface IAdminUIService
    {
        Task<List<User>> GetAllUsers();
        Task DeleteUser(int userId);
    }

    public class AdminUIService : IAdminUIService
    {
        private readonly HttpClient httpClient;

        public AdminUIService(HttpClient client)
        {
            this.httpClient = client;
   // Replace with your API base address
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await httpClient.GetFromJsonAsync<List<User>>("Admin/GetAllUsers"); // Adjust the endpoint as per your API
        }

        public async Task DeleteUser(int userId)
        {
            await httpClient.DeleteAsync($"Admin/Users/{userId}"); // Adjust the endpoint as per your API
        }
    }
}
