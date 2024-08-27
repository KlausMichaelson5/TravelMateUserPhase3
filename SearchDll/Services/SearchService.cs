﻿using CabBookingDll.Models;
using CabDll.Models;
using HotelDll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDll.Services
{
    public interface ISearchService
    {
        List<Hotel> GetAllHotels();
        List<Cab> GetAllCabs();
        List<Cabbooking> GetAllCabBookings();

    }
    public class SearchService : ISearchService
    {
        private readonly HotelDbContext _Hotelcontext;
        private readonly CabDbContext _Cabcontext;
        private readonly CabBookingDbContext _CabBookingcontext;

        public SearchService(HotelDbContext hotelContext, CabDbContext cabContext, CabBookingDbContext cabDbContext)
        {
            _Hotelcontext = hotelContext;
            _Cabcontext = cabContext;
            _CabBookingcontext = cabDbContext;
        }

        public List<Hotel> GetAllHotels()
        {
            return _Hotelcontext.Hotels
                .Select(hotelEntity => new Hotel
                {
                    HotelId = hotelEntity.HotelId,
                    HotelOwnerId = hotelEntity.HotelOwnerId,
                    Name = hotelEntity.Name,
                    Address = hotelEntity.Address,
                    City = hotelEntity.City,
                    State = hotelEntity.State,
                    Country = hotelEntity.Country,
                    ZipCode = hotelEntity.ZipCode,
                    Description = hotelEntity.Description,
                    Latitude = hotelEntity.Latitude,
                    Longitude = hotelEntity.Longitude,
                    Rating = hotelEntity.Rating,
                    AvailabilityStatus = hotelEntity.AvailabilityStatus,
                    HotelImage = hotelEntity.HotelImage
                })
                .ToList();
        }

        public List<Cab> GetAllCabs()
        {
            return _Cabcontext.Cabs
                .Select(cabEntity => new Cab
                {
                    CabId = cabEntity.CabId,
                    DriverId = cabEntity.DriverId,
                    VehicleName = cabEntity.VehicleName,
                    RegistrationNumber = cabEntity.RegistrationNumber,
                    LicenseNumber = cabEntity.LicenseNumber,
                    CabPhoto = cabEntity.CabPhoto,
                    DriverPhoto = cabEntity.DriverPhoto,
                    Latitude = cabEntity.Latitude,
                    Longitude = cabEntity.Longitude,
                    AvailabilityStatus = cabEntity.AvailabilityStatus,
                    VehicleType = cabEntity.VehicleType,
                    NumberOfSeats = cabEntity.NumberOfSeats,
                    PricePerKm = cabEntity.PricePerKm,
                    Rating = cabEntity.Rating
                })
                .ToList();
        }

        public List<Cabbooking> GetAllCabBookings()
        {
            return _CabBookingcontext.CabBookings.ToList();
        }
    }
}
