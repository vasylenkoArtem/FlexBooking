using FlexBooking.Domain.Enums;

namespace FlexBooking.Logic.Aggregates.Booking.Models;

public class BookingViewModel
{
    public string? UserFullName { get; set; }
    public int BookingOfferId { get; set; }
    public int? PassengerSeats { get; set; }
    public float? Price { get; set; }
    public string? Comment { get; set; }
    public BookingStatusEnum Status { get; set; }


    public BookingViewModel(Domain.Models.Booking booking)
    {
        UserFullName = booking.UserFullName;
        BookingOfferId = booking.BookingOfferId;
        PassengerSeats = booking.PassengerSeats;
        Price = booking.Price;
        Comment = booking.Comment;
        Status = booking.Status;
    }
}