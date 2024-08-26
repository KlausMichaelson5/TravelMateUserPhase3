using CabBooking.DataServices;
using CabBookingDll.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CabBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("cors")]
    public class CabBookingController : Controller
    {
        private readonly CabBookingDataServices _cabBookingDataServices;

        public CabBookingController(CabBookingDataServices cabBookingDataServices)
        {
            _cabBookingDataServices = cabBookingDataServices;
        }

        // POST: api/cabbooking
        [HttpPost]
        public async Task<IActionResult> AddCabBooking([FromBody] Cabbooking cabBooking, [FromQuery] int currentUserId)
        {
            try
            {
                await _cabBookingDataServices.AddCabBookingAsync(cabBooking, currentUserId);
                return Ok(new { Message = "Cab booking added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/cabbooking/{id}
        [HttpGet("{cabBookingId}")]
        public async Task<IActionResult> GetCabBooking(int cabBookingId, [FromQuery] int currentUserId)
        {
            try
            {
                var cabBooking = await _cabBookingDataServices.GetCabBookingAsync(cabBookingId, currentUserId);
                return Ok(cabBooking);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/cabbooking/{id}
        [HttpDelete("{cabBookingId}")]
        public async Task<IActionResult> DeleteCabBooking(int cabBookingId, [FromQuery] int currentUserId)
        {
            try
            {
                await _cabBookingDataServices.DeleteCabBookingAsync(cabBookingId, currentUserId);
                return Ok(new { Message = "Cab booking deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/cabbooking
        [HttpGet]
        public async Task<IActionResult> GetAllCabBookings([FromQuery] int currentUserId)
        {
            try
            {
                var bookings = await _cabBookingDataServices.GetAllCabBookingsAsync(currentUserId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
