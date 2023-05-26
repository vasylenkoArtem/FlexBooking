using System.ComponentModel.DataAnnotations;
using FlexBooking.Domain.Enums;

namespace FlexBooking.Domain.Models;

public class Booking
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? PassportFullName { get; set; }
    public string? PassportNumber { get; set; }
    public string? VisaNumber { get; set; }
    public int BookingOfferId { get; set; }
    public int? PassengerSeats { get; set; }
    public float? Price { get; set; }
    public string? Comment { get; set; }
    public BookingStatusEnum Status { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public User User { get; set; }
    public BookingOffer BookingOffer { get; set; }

    public string? CardNumber { get; set; }
    
    public string? Cvv { get; set; }

    public DateTime? ExpiryDate { get; set; }
    public string? BillingAddress { get; set; }
    public List<HotelOffer>? HotelOffers { get; set; }
    public List<CarOffer>? CarRentalOffers { get; set; }
}