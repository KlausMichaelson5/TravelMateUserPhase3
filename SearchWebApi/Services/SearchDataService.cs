using CabDll.Models;
using CabDll.Services;
using HotelDll.Models;
using HotelDll.Services;
using SearchDll.Services;

namespace SearchWebApi.Services
{
    public interface ISearchDataService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<List<Cab>> GetAllCabs();
    }
    public class SearchDataService : ISearchDataService
    {
        private readonly ISearchService _searchService;

        public SearchDataService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            // Converting synchronous method to asynchronous using Task.Run
            return await Task.Run(() => _searchService.GetAllHotels());
        }

        public async Task<List<Cab>> GetAllCabs()
        {
            // Converting synchronous method to asynchronous using Task.Run
            return await Task.Run(() => _searchService.GetAllCabs());
        }
    }
}
