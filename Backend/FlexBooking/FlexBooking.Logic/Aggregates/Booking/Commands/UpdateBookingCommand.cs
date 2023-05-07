using FlexBooking.Logic.Aggregates.Booking.Models;
using MediatR;

namespace FlexBooking.Logic.Aggregates.Booking.Commands;

public class UpdateBookingCommand : IRequest<int>
{
    public int BookingId { get; set; }
    public BookingViewModel BookingViewModel { get; set; }

    public UpdateBookingCommand(int bookingId, BookingViewModel bookingViewModel)
    {
        BookingId = bookingId;
        BookingViewModel = bookingViewModel;
    }
}