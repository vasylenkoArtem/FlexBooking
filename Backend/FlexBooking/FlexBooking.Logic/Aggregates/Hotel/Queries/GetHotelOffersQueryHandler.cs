using FlexBooking.Domain;
using FlexBooking.Logic.Aggregates.Hotel.Models;
using FlexBooking.Logic.Queries;
using FlexBooking.Logic.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Handlers;

public class GetHotelOffersQueryHandler : IRequestHandler<GetHotelOffersQuery, List<HotelOfferViewModel>>
{
    private readonly IFlexBookingContext _context;

    public GetHotelOffersQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }

    public async Task<List<HotelOfferViewModel>> Handle(GetHotelOffersQuery request,
        CancellationToken cancellationToken)
    {
        var domainHotels = await _context.HotelOffers
            .Where(x => string.IsNullOrEmpty(request.City) || x.City == request.City)
            .ToListAsync(cancellationToken);

        return domainHotels.Select(domainOffer => new HotelOfferViewModel()
        {
            City = domainOffer.City,
            Id = domainOffer.Id,
            Price = domainOffer.Price,
            HotelRoomImageUrl = domainOffer.HotelRoomImageUrl
        }).ToList();
    }
}