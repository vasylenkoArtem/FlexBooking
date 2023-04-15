namespace FlexBooking.Logic.Aggregates.CarRental.Models;

public class CarRentalOfferViewModel
{
    public int Id { get; set; }

    public string City { get; set; }

    public string CarImageUrl { get; set; }

    public decimal Price { get; set; }
}