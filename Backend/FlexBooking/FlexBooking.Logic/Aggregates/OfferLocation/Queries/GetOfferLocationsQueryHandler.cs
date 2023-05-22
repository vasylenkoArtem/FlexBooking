using FlexBooking.Domain;
using FlexBooking.Logic.Aggregates.Booking.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Aggregates.OfferLocation.Queries;

public class GetOfferLocationsQueryHandler : IRequestHandler<GetOfferLocationsQuery, List<OfferLocationDto>>
{
    private readonly IFlexBookingContext _context;

    public GetOfferLocationsQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }

    public async Task<List<OfferLocationDto>> Handle(GetOfferLocationsQuery request,
        CancellationToken cancellationToken)
    {
        var offerLocations = await _context.OfferLocations
            .ToListAsync(cancellationToken);

        return offerLocations.Select(x => new OfferLocationDto()
        {
            City = x.City,
            Id = x.Id,
            AirportCode = x.AirportCode,
            BusStation = x.BusStation,
            TrainStation = x.TrainStation
        }).ToList();
    }
}