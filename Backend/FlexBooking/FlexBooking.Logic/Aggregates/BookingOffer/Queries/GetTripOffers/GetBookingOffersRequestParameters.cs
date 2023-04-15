namespace FlexBooking.Logic.DTOs;

public class GetBookingOffersRequestParameters
{
    // request body:
    // {
    //     originCity: string,
    //     destinationCity: string,
    //     departureDate: DateTime,
    //     arrivalDate: DateTime,
    //     passengersCount: int
    // }
    
    public string OriginCity { get; set; }
    public string DestinationCity { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public int PassengersCount { get; set; }
}