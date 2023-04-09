﻿using FlexBooking.Domain;
using FlexBooking.Logic.Queries;
using FlexBooking.Logic.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlexBooking.Logic.Handlers;

public class GetTripOffersQueryHandler: IRequestHandler<GetTripOffersQuery, List<BookingOffersViewModel>>
{
    private readonly IFlexBookingContext _context;

    public GetTripOffersQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<List<BookingOffersViewModel>> Handle(GetTripOffersQuery request, CancellationToken cancellationToken)
    {
        var bookingOffers = await _context.BookingOffers
            .Include(bo => bo.OriginOfferLocation)
            .Include(bo => bo.DestinationOfferLocation)
            .Where(bo => bo.OriginOfferLocation.City == request.BookingOffersDTO.OriginCity
                         && bo.DestinationOfferLocation.City == request.BookingOffersDTO.DestinationCity
                         && bo.DepartureDateUtc >= request.BookingOffersDTO.DepartureDate
                         && bo.ArrivalDateUtc <= request.BookingOffersDTO.ArrivalDate
                         && bo.AvailablePassengerSeats >= request.BookingOffersDTO.PassengersCount)
            .ToListAsync(cancellationToken);
        
        return bookingOffers.Select(bo => new BookingOffersViewModel(bo)).ToList();
    }
}