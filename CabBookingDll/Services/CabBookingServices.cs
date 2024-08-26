using CabBookingDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBookingDll.Services
{
    public interface ICabBookingServices
    {
        void Add(Cabbooking cabBooking, int currentUserId);
        void Delete(int cabBookingId, int currentUserId);
        Cabbooking Get(int cabBookingId, int currentUserId);
        List<Cabbooking> GetAll(int currentUserId);
    }

    public class CabBookingServices : ICabBookingServices
    {
        private readonly CabBookingDbContext _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public CabBookingServices(CabBookingDbContext context)
        {
            _context = context;
        }

        public Cabbooking Get(int cabBookingId, int currentUserId)
        {
            var cabBookingEntity = _context.CabBookings
                .FirstOrDefault(b => b.CabbookingId == cabBookingId && b.UserId == currentUserId);

            if (cabBookingEntity == null)
            {
                throw new Exception("No cab booking found for the current user.");
            }

            return cabBookingEntity;
        }

        public void Add(Cabbooking cabBooking, int currentUserId)
        {
            var cabBookingEntity = new Cabbooking
            {
                UserId = currentUserId,
                CabId = cabBooking.CabId,
                PickupLocation = cabBooking.PickupLocation,
                DropLocation = cabBooking.DropLocation,
                Distance = cabBooking.Distance,
                TotalAmount = cabBooking.TotalAmount,
                BookingStatus = cabBooking.BookingStatus
            };

            _context.CabBookings.Add(cabBookingEntity);
            _context.SaveChanges();
        }

        public void Delete(int cabBookingId, int currentUserId)
        {
            var cabBookingEntity = _context.CabBookings.Find(cabBookingId);

            if (cabBookingEntity == null || cabBookingEntity.UserId != currentUserId)
            {
                throw new Exception("Cab booking not found or you do not have access to delete.");
            }

            _context.CabBookings.Remove(cabBookingEntity);
            _context.SaveChanges();
        }

        public List<Cabbooking> GetAll(int currentUserId)
        {
            return _context.CabBookings
                 .Where(b => b.UserId == currentUserId)
                 .ToList();
        }


    }
}
