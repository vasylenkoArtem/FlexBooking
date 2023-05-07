using FlexBooking.Domain.Enums;

namespace FlexBooking.Logic.Aggregates.Booking.Models;

public class BookingViewModel
{
    public string? PassportFullName { get; set; }
    public string? PassportNumber { get; set; }
    public string? VisaNumber { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int BookingOfferId { get; set; }
    public int? PassengerSeats { get; set; }
    public float? Price { get; set; }
    public string? Comment { get; set; }
    public BookingStatusEnum Status { get; set; }


    public BookingViewModel(Domain.Models.Booking booking)
    {
        PassportFullName = booking.PassportFullName;
        PassportNumber = booking.PassportNumber;
        VisaNumber = booking.VisaNumber;
        Email = booking.User.Email;
        Phone = booking.User.Phone;
        BookingOfferId = booking.BookingOfferId;
        PassengerSeats = booking.PassengerSeats;
        Price = booking.Price;
        Comment = booking.Comment;
        Status = booking.Status;
    }
}