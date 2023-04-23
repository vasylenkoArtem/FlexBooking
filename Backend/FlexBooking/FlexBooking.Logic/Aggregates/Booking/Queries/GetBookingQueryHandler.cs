using FlexBooking.Domain;
using FlexBooking.Logic.Aggregates.Booking.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Aggregates.Booking.Queries;

public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingViewModel>
{
    private readonly IFlexBookingContext _context;

    public GetBookingQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<BookingViewModel> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings
            .Include(x => x.BookingOffer)
            .Include(x => x.CarOffers)
            .Include(x => x.HotelOffers)
            .FirstOrDefaultAsync(x => x.Id == request.BookingId, cancellationToken: cancellationToken);

        return new BookingViewModel(booking);
    }
}