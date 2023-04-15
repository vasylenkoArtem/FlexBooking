using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Queries;

public class GetTripOffersQuery: IRequest<List<BookingOffersViewModel>>
{
    public GetBookingOffersRequestParameters GetBookingOffersRequestParameters { get; set; }
    
    public GetTripOffersQuery(GetBookingOffersRequestParameters getBookingOffersRequestParameters)
    {
        GetBookingOffersRequestParameters = getBookingOffersRequestParameters;
    }
}