using FlexBooking.Logic.Aggregates.BookingOffer.Dto;
using FlexBooking.Logic.Aggregates.OfferLocation;

namespace FlexBooking.API.Requests;

public class AddBookingOfferRequest
{
    public BookingOfferDto BookingOffer { get; set; }

    public OfferLocationDto? NewOriginLocation { get; set; }
    
    public OfferLocationDto? NewDestinationLocation { get; set; }
}