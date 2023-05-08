using FlexBooking.Logic.Aggregates.Booking.Models;
using MediatR;

namespace FlexBooking.Logic.Aggregates.Booking.Commands;

public class UpdateBookingCommand : IRequest<int>
{
    public int BookingId { get; set; }
    public UpdateBookingViewModel BookingViewModel { get; set; }

    public UpdateBookingCommand(int bookingId, UpdateBookingViewModel bookingViewModel)
    {
        BookingId = bookingId;
        BookingViewModel = bookingViewModel;
    }
}