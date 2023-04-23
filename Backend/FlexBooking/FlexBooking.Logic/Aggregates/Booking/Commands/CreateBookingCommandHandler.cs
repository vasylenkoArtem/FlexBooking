using FlexBooking.Domain;
using FlexBooking.Domain.Enums;
using MediatR;

namespace FlexBooking.Logic.Aggregates.Booking.Commands;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
{
    private readonly IFlexBookingContext _context;

    public CreateBookingCommandHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        // We will pass userId from the request for now, until we don't have fully implemented authentication
        var booking = new Domain.Models.Booking
        {
            BookingOfferId = request.BookingOfferId,
            UserId = request.UserId,
            Status = BookingStatusEnum.New,
            CreatedAtUtc = DateTime.UtcNow
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return booking.Id;
    }
}