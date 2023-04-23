using FlexBooking.Logic.Aggregates.Booking.Models;
using MediatR;

namespace FlexBooking.Logic.Aggregates.Booking.Queries;

public class GetBookingQuery : IRequest<BookingViewModel>
{
    public GetBookingQuery(int bookingId)
    {
        BookingId = bookingId;
    }
    public int BookingId { get; set; }
}