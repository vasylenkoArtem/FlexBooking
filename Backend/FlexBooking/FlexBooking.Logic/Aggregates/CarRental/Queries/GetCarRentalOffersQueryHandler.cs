using FlexBooking.Domain;
using FlexBooking.Logic.Aggregates.CarRental.Models;
using FlexBooking.Logic.Aggregates.Hotel.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Aggregates.CarRental.Queries;

public class GetCarRentalOffersQueryHandler: IRequestHandler<GetCarRentalOffersQuery, List<CarRentalOfferViewModel>>
{
    private readonly IFlexBookingContext _context;

    public GetCarRentalOffersQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<List<CarRentalOfferViewModel>> Handle(GetCarRentalOffersQuery request, CancellationToken cancellationToken)
    {
        var domainCarRentals = await _context.CarOffers
            .Where(x => string.IsNullOrEmpty(request.City) || x.City == request.City)
            .ToListAsync(cancellationToken);

        return domainCarRentals.Select(domainOffer => new CarRentalOfferViewModel()
        {
            City = domainOffer.City,
            Id = domainOffer.Id,
            Price = domainOffer.Price,
            CarImageUrl = domainOffer.CarImageUrl
        }).ToList();
    }
}