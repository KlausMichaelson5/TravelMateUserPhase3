﻿using Microsoft.AspNetCore.Mvc;
using SearchWebApi.Services;

namespace SearchWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchDataService _searchDataService;

        public SearchController(ISearchDataService searchDataService)
        {
            _searchDataService = searchDataService;
        }

        [HttpGet("hotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _searchDataService.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet("cabs")]
        public async Task<IActionResult> GetAllCabs()
        {
            var cabs = await _searchDataService.GetAllCabs();
            return Ok(cabs);
        }
    }
}
