using MediatR;

namespace FlexBooking.Logic.Aggregates.Booking.Commands;

public class CreateBookingCommand : IRequest<int>
{
    public CreateBookingCommand(int bookingOfferId, int userId)
    {
        BookingOfferId = bookingOfferId;
        UserId = userId;
    }
    
    public int BookingOfferId { get; set; }
    public int UserId { get; set; }
}