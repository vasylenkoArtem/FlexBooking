using System.ComponentModel.DataAnnotations;

namespace FlexBooking.Domain.Models;

//TBD, MVP
public class CarOffer
{
    [Key]
    public int Id { get; set; }

    public string City { get; set; }

    public string CarImageUrl { get; set; }

    public decimal Price { get; set; }
    
    public string Title { get; set; }
    public Booking? Booking { get; set; }
}