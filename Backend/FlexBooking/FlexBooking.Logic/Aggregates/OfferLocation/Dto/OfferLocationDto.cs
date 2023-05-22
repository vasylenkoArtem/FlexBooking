namespace FlexBooking.Logic.Aggregates.OfferLocation;

public class OfferLocationDto
{
    public int Id { get; set; }

    public string City { get; set; }

    public string? AirportCode { get; set; }

    public string? TrainStation { get; set; }

    public string? BusStation { get; set; }
}