using System.ComponentModel.DataAnnotations;

namespace TravelMate.Models
{
    public class CabBookingModel
    {
        public int CabBookingId { get; set; } 
        public int UserId { get; set; }
        public int CabId { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public double Distance { get; set; } 
        public decimal TotalAmount { get; set; }
        public string BookingStatus { get; set; }
    }
}
