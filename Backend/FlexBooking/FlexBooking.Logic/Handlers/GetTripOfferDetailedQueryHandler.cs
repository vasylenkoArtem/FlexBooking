using FlexBooking.Domain;
using FlexBooking.Logic.Queries;
using FlexBooking.Logic.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Handlers;

public class GetTripOfferDetailedQueryHandler: IRequestHandler<GetTripOfferDetailedQuery, BookingOffersViewModel>
{
    private readonly IFlexBookingContext _context;

    public GetTripOfferDetailedQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<BookingOffersViewModel> Handle(GetTripOfferDetailedQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.BookingOffers
            .Include(bo => bo.OriginOfferLocation)
            .Include(bo => bo.DestinationOfferLocation)
            .Where(bo => bo.Id == request.Id)
            .Select(bo => new BookingOffersViewModel(bo))
            .FirstOrDefaultAsync(cancellationToken);
        
        return result ?? throw new Exception("Booking offer not found");
    }
}