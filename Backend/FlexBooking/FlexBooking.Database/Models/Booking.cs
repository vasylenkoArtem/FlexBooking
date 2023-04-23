using System.ComponentModel.DataAnnotations;
using FlexBooking.Domain.Enums;

namespace FlexBooking.Domain.Models;

public class Booking
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? UserFullName { get; set; }
    public int BookingOfferId { get; set; }
    public int? PassengerSeats { get; set; }
    public float? Price { get; set; }
    public string? Comment { get; set; }
    public BookingStatusEnum Status { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public User User { get; set; }
    public BookingOffer BookingOffer { get; set; }


    public int? CarOfferId { get; set; }
    public int? HotelOfferId { get; set; }
    public CarOffer? CarOffers { get; set; }
    public HotelOffer? HotelOffers { get; set; }
}