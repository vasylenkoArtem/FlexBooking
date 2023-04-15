using FlexBooking.Domain.Enums;
using FlexBooking.Domain.Models;

namespace FlexBooking.Logic.ViewModels;

public class BookingOffersViewModel
{
//     response body:
//     {
//         id: int;
//         offerTypeId: int;
//         originOfferLocation: {
//          //full OfferLocation from backend
//         }
//         destinationOfferLocation: {
//          //full OfferLocation from backend
//         }
//         departureDateUtc: Date;
//         arrivalDateUtc: Date;
//         price: float;
//         companyLogoUrl: string;
//     }

    public BookingOffersViewModel(BookingOffer bookingOffer)
    {
        Id = bookingOffer.Id;
        OfferTypeId = bookingOffer.OfferTypeId;
        OriginOfferLocation = bookingOffer.OriginOfferLocation;
        DestinationOfferLocation = bookingOffer.DestinationOfferLocation;
        DepartureDateUtc = bookingOffer.DepartureDateUtc;
        ArrivalDateUtc = bookingOffer.ArrivalDateUtc;
        Price = bookingOffer.Price;
        CompanyLogoUrl = bookingOffer.CompanyLogoUrl;
    }

    public int Id { get; set; }
    public OfferType OfferTypeId { get; set; }
    public OfferLocation OriginOfferLocation { get; set; }
    public OfferLocation DestinationOfferLocation { get; set; }
    public DateTime DepartureDateUtc { get; set; }
    public DateTime ArrivalDateUtc { get; set; }
    public float Price { get; set; }
    public string CompanyLogoUrl { get; set; }
}