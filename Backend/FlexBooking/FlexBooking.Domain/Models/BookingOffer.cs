using System.ComponentModel.DataAnnotations;
using FlexBooking.Domain.Enums;

namespace FlexBooking.Domain.Models;

//TBD, MVP
public class BookingOffer
{
    [Key]
    public int Id { get; set; }

    public OfferType OfferTypeId { get; set; }

    public int OriginOfferLocationId { get; set; }

    public int DestinationOfferLocationId { get; set; }

    public DateTime DepartureDateUtc { get; set; }

    public DateTime ArrivalDateUtc { get; set; }

    public int AvailablePassengerSeats { get; set; }
    
    public float Price { get; set; }
    
    public string CompanyLogoUrl { get; set; }


    public OfferLocation OriginOfferLocation { get; set; }

    public OfferLocation DestinationOfferLocation { get; set; }
}