namespace FlexBooking.Logic.DTOs;

public class GetBookingOffersRequestParameters
{
    public string? OriginCity { get; set; }
    public string? DestinationCity { get; set; }
    public DateTime? DepartureDate { get; set; }
    public DateTime? ArrivalDate { get; set; }
    public int? PassengersCount { get; set; }
}