using FlexBooking.Domain;
using FlexBooking.Domain.Enums;
using MediatR;

namespace FlexBooking.Logic.Aggregates.BookingOffer.Commands;

public class AddBookingOfferCommandHandler : IRequestHandler<AddBookingOfferCommand, Unit>
{
    private readonly IFlexBookingContext _context;

    public AddBookingOfferCommandHandler(IFlexBookingContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddBookingOfferCommand request, CancellationToken cancellationToken)
    {
        var dtoModel = request.BookingOffer;

        var domainOffer = new Domain.Models.BookingOffer()
        {
            Price = (float)dtoModel.Price,
            ArrivalDateUtc = dtoModel.ArrivalDate,
            DepartureDateUtc = dtoModel.DepartureDate,
            CompanyLogoUrl = dtoModel.CompanyLogoUrl,
            AvailablePassengerSeats = dtoModel.AvailablePassengerSeats,
            DestinationOfferLocationId = dtoModel.DestinationId,
            OriginOfferLocationId = dtoModel.OriginId,
            OfferTypeId = (OfferType)dtoModel.OfferTypeId
        };

        await _context.BookingOffers.AddAsync(domainOffer, cancellationToken);

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}