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
            new() { Id = 1, Username = "TestClient", Password = "123456", RoleId = UserRoles.Client },
            new() { Id = 2, Username = "TestAdmin", Password = "123456", RoleId = UserRoles.Admin }
        });

        modelBuilder.Entity<OfferLocation>().HasData(new List<OfferLocation>()
        {
            new() {Id = 1, City = "Toronto", AirportCode = "YYZ"},
            new() {Id = 2, City = "Montreal", AirportCode = "YUL"},
            new() {Id = 3, City = "Toronto", TrainStation = "Union Station"},
            new() {Id = 4, City = "Montreal", TrainStation = "Central Station"},
            new() {Id = 5, City = "Toronto", BusStation = "Toronto Bus Station"},
            new() {Id = 6, City = "Montreal", BusStation = "Montreal Bus Station"},
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
                CompanyLogoUrl = "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png"
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
                CompanyLogoUrl = "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png"
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
                CompanyLogoUrl = "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png"
            }
        });
        
        modelBuilder.Entity<CarOffer>().HasData(new List<CarOffer>()
        {
            new() {Id = 1, City = "Toronto", CarImageUrl = "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", Price = 100},
            new() {Id = 2, City = "Montreal", CarImageUrl = "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", Price = 100}
        });
        
        modelBuilder.Entity<HotelOffer>().HasData(new List<HotelOffer>()
        {
            new() {Id = 1, City = "Toronto", HotelRoomImageUrl = "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", Price = 100},
            new() {Id = 2, City = "Montreal", HotelRoomImageUrl = "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", Price = 100}
        });
    }
}