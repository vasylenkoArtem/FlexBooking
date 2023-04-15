using FlexBooking.Domain;
using FlexBooking.Logic.Queries;
using FlexBooking.Logic.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Handlers;

public class GetTripOffersQueryHandler : IRequestHandler<GetTripOffersQuery, List<BookingOffersViewModel>>
{
    private readonly IFlexBookingContext _context;

    public GetTripOffersQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }

    public async Task<List<BookingOffersViewModel>> Handle(GetTripOffersQuery request,
        CancellationToken cancellationToken)
    {
        var bookingOffers = await _context.BookingOffers
            .Include(bo => bo.OriginOfferLocation)
            .Include(bo => bo.DestinationOfferLocation)
            .Where(bo =>
                (string.IsNullOrEmpty(request.GetBookingOffersRequestParameters.OriginCity) ||
                 bo.OriginOfferLocation.City == request.GetBookingOffersRequestParameters.OriginCity)
                && (string.IsNullOrEmpty(request.GetBookingOffersRequestParameters.DestinationCity) ||
                    bo.DestinationOfferLocation.City == request.GetBookingOffersRequestParameters.DestinationCity)
                && (!request.GetBookingOffersRequestParameters.DepartureDate.HasValue || bo.DepartureDateUtc >=
                    request.GetBookingOffersRequestParameters.DepartureDate)
                && (!request.GetBookingOffersRequestParameters.ArrivalDate.HasValue ||
                    bo.ArrivalDateUtc <= request.GetBookingOffersRequestParameters.ArrivalDate)
                && (request.GetBookingOffersRequestParameters.PassengersCount == default || bo.AvailablePassengerSeats >=
                    request.GetBookingOffersRequestParameters.PassengersCount)
            )
            .ToListAsync(cancellationToken);

        return bookingOffers.Select(bo => new BookingOffersViewModel(bo)).ToList();
    }
}