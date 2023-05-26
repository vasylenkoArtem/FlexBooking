namespace FlexBooking.Logic.Aggregates.Booking.Models;

public class UpdateBookingViewModel : BookingViewModel
{
    public string? CardNumber { get; set; }

    public string? Cvv { get; set; }

    public DateTime? ExpiryDate { get; set; }

    //todo: maybe make with more fields
    public string? BillingAddress { get; set; }

    
    //TODO: add some info
    public List<int>? HotelOfferIds { get; set; }
    
    public List<int>? CarRentalOfferIds { get; set; }
}