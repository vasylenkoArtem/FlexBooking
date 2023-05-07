using FlexBooking.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Aggregates.Booking.Commands;

public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
{
    private readonly IFlexBookingContext _context;

    public UpdateBookingCommandHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var booking = _context.Bookings
                .Include(b => b.User)
                .SingleOrDefault(b => b.Id == request.BookingId);
        
            booking.PassportFullName = request.BookingViewModel.PassportFullName;
            booking.PassportNumber = request.BookingViewModel.PassportNumber;
            booking.VisaNumber = request.BookingViewModel.VisaNumber;
            booking.BookingOfferId = request.BookingViewModel.BookingOfferId;
            booking.PassengerSeats = request.BookingViewModel.PassengerSeats;
            booking.Price = request.BookingViewModel.Price;
            booking.Comment = request.BookingViewModel.Comment;
            booking.Status = request.BookingViewModel.Status;

            if (request.BookingViewModel.Phone != null)
            {
                booking.User.Phone = request.BookingViewModel.Phone;
            }

            if (request.BookingViewModel.Email != null)
            {
                booking.User.Email = request.BookingViewModel.Email;
            }
        
            _context.Bookings.Update(booking);
        
            await _context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(request.BookingId);
        }
        catch (Exception e)
        {
            Console.WriteLine("Booking not found" + e);
            throw;
        }
        
    }
}