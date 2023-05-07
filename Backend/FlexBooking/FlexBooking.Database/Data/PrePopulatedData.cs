using FlexBooking.Domain.Enums;
using FlexBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Domain.Data;

public static class PrePopulatedData
{
    public static void Populate(ModelBuilder modelBuilder)
    {
        // BookingOffers
        modelBuilder.Entity<User>().HasData(new List<User>()
        {
            new() { Id = 1, Username = "TestClient", Password = "123456", RoleId = UserRoles.Client, Phone = "+1999999999", Email = "test@i.ua"},
            new() { Id = 2, Username = "TestAdmin", Password = "123456", RoleId = UserRoles.Admin, Phone = "+1999999999", Email = "test@i.ua" }
        });

        modelBuilder.Entity<OfferLocation>().HasData(new List<OfferLocation>()
        {
            new() { Id = 1, City = "Toronto", AirportCode = "YYZ" },
            new() { Id = 2, City = "Montreal", AirportCode = "YUL" },
            new() { Id = 3, City = "Toronto", TrainStation = "Union Station" },
            new() { Id = 4, City = "Montreal", TrainStation = "Central Station" },
            new() { Id = 5, City = "Toronto", BusStation = "Toronto Bus Station" },
            new() { Id = 6, City = "Montreal", BusStation = "Montreal Bus Station" },
        });

        modelBuilder.Entity<BookingOffer>().HasData(new List<BookingOffer>()
        {
            new()
            {
                Id = 1,
                OriginOfferLocationId = 1,
                DestinationOfferLocationId = 2,
                DepartureDateUtc = DateTime.UtcNow,
                ArrivalDateUtc = DateTime.UtcNow.Add(TimeSpan.FromHours(6)),
                AvailablePassengerSeats = 100,
                OfferTypeId = OfferType.Flight,
                Price = 800,
                CompanyLogoUrl =
                    "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png"
            },
            new()
            {
                Id = 2,
                OriginOfferLocationId = 3,
                DestinationOfferLocationId = 4,
                DepartureDateUtc = DateTime.UtcNow,
                ArrivalDateUtc = DateTime.UtcNow.Add(TimeSpan.FromHours(6)),
                AvailablePassengerSeats = 100,
                OfferTypeId = OfferType.Train,
                Price = 250,
                CompanyLogoUrl =
                    "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png"
            },
            new()
            {
                Id = 3,
                OriginOfferLocationId = 5,
                DestinationOfferLocationId = 6,
                DepartureDateUtc = DateTime.UtcNow,
                ArrivalDateUtc = DateTime.UtcNow.Add(TimeSpan.FromHours(6)),
                AvailablePassengerSeats = 100,
                OfferTypeId = OfferType.Bus,
                Price = 100,
                CompanyLogoUrl =
                    "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png"
            }
        });

        modelBuilder.Entity<CarOffer>().HasData(new List<CarOffer>()
        {
            new()
            {
                Id = 1, City = "Toronto",
                CarImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/toyota/camry_lrg.jpg", 
                Price = 100,
                Title = "Regular sedan Audi"
            },
            new()
            {
                Id = 2, City = "Montreal",
                CarImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/dodge/durango_lrg.jpg", 
                Price = 120,
                Title = "Special SUV BMW X2"
            }
        });

        modelBuilder.Entity<HotelOffer>().HasData(new List<HotelOffer>()
        {
            new()
            {
                Id = 1, 
                City = "Toronto",
                HotelRoomImageUrl =
                    "https://cf.bstatic.com/xdata/images/hotel/square200/64371688.webp?k=5ef28b75a00b6ef33e969c56783827d927a8a5d3bdfdd71c450b6477d725a7b7&o=&s=1",
                Price = 70,
                Title = "San Marine Hotel 4 Star"
            },
            new()
            {
                Id = 2, 
                City = "Montreal",
                HotelRoomImageUrl =
                    "https://cf.bstatic.com/xdata/images/hotel/square200/232812146.webp?k=76f9ea6d899b7ff326616e78653a8b83af7b276dd74ed07ed7d04a7e8c5c8aa6&o=&s=1",
                Price = 115,
                Title = "Amazing View to Falls Hotel"
            }
        });
    }
}