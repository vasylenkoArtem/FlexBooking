using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Queries;

public class GetTripOfferDetailedQuery: IRequest<BookingOffersViewModel>
{
    public int Id { get; }
    
    public GetTripOfferDetailedQuery(int id)
    {
        Id = id;
    }
}