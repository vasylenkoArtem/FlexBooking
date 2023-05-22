using FlexBooking.Domain;
using MediatR;

namespace FlexBooking.Logic.Aggregates.OfferLocation;

public class AddOfferLocationCommandHandler : IRequestHandler<AddOfferLocationCommand, int>
{
    private readonly IFlexBookingContext _context;

    public AddOfferLocationCommandHandler(IFlexBookingContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddOfferLocationCommand request, CancellationToken cancellationToken)
    {
        var domainOfferLocation = new Domain.Models.OfferLocation()
        {
            City = request.OfferLocation.City,
            AirportCode = request.OfferLocation.AirportCode,
            BusStation = request.OfferLocation.BusStation,
            TrainStation = request.OfferLocation.TrainStation,
        };

        _context.OfferLocations.Add(domainOfferLocation);
        
        await _context.SaveChangesAsync(cancellationToken);

        return domainOfferLocation.Id;
    }
}