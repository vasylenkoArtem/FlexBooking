using FlexBooking.Domain.Enums;

namespace FlexBooking.Logic.Aggregates.Booking.Models;

public class UpdateBookingViewModel : BookingViewModel
{
    public string? CardNumber { get; set; }
    public string? Cvv { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? BillingAddress { get; set; }
}