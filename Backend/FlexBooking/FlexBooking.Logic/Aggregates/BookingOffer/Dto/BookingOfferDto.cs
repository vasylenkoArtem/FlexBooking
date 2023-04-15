namespace FlexBooking.Logic.Aggregates.BookingOffer.Dto;

public class BookingOfferDto
{
    public DateTime ArrivalDate { get; set; }

    public DateTime DepartureDate { get; set; }

    public int AvailablePassengerSeats { get; set; }

    public string CompanyLogoUrl { get; set; }

    public int DestinationId { get; set; }

    public int OriginId { get; set; }

    public int OfferTypeId { get; set; }

    public decimal Price { get; set; }
}