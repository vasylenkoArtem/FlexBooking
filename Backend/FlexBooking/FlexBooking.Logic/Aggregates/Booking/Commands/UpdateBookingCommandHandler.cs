using FlexBooking.Domain;
using FlexBooking.Domain.Enums;
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

            var totalBookingPrice = 0;
            
            booking.PassportFullName = request.BookingViewModel.PassportFullName;
            booking.PassportNumber = request.BookingViewModel.PassportNumber;
            booking.VisaNumber = request.BookingViewModel.VisaNumber;
            booking.BookingOfferId = request.BookingViewModel.BookingOfferId;
            booking.PassengerSeats = request.BookingViewModel.PassengerSeats;

            var bookingOffer =
                await _context.BookingOffers.FirstOrDefaultAsync(x => x.Id == request.BookingViewModel.BookingOfferId);
            totalBookingPrice += (int)bookingOffer.Price;
            
            booking.Price = bookingOffer.Price;
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

            booking.CardNumber = request.BookingViewModel.CardNumber;
            booking.Cvv = request.BookingViewModel.Cvv;
            booking.ExpiryDate = request.BookingViewModel.ExpiryDate;
            booking.BillingAddress = request.BookingViewModel.BillingAddress;

            if (booking.CardNumber != null)
            {
                booking.Status = BookingStatusEnum.Confirmed;
            }

            if (request.BookingViewModel.HotelOfferIds?.Any() != null)
            {
                var hotelOffers = await _context.HotelOffers.Where(x => request.BookingViewModel.HotelOfferIds.Contains(x.Id)).ToListAsync();
                booking.HotelOffers = hotelOffers;
                
                totalBookingPrice += (int)hotelOffers.Sum(x => x.Price);
            }
            
            if (request.BookingViewModel.CarRentalOfferIds?.Any() != null)
            {
                var carRentals = await _context.CarOffers.Where(x => request.BookingViewModel.CarRentalOfferIds.Contains(x.Id)).ToListAsync();
                booking.CarRentalOffers = carRentals;
                
                totalBookingPrice += (int)carRentals.Sum(x => x.Price);
            }

            booking.Price = totalBookingPrice;

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