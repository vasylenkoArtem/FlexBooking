using System.ComponentModel.DataAnnotations;

namespace FlexBooking.Domain.Models;

public class HotelOffer
{
    [Key]
    public int Id { get; set; }

    public string City { get; set; }

    public string HotelRoomImageUrl { get; set; }

    public decimal Price { get; set; }
}