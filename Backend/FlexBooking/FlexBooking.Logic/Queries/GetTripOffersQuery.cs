using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Queries;

public class GetTripOffersQuery: IRequest<List<BookingOffersViewModel>>
{
    public BookingOffersDTO BookingOffersDTO { get; set; }
    
    public GetTripOffersQuery(BookingOffersDTO bookingOffersDTO)
    {
        BookingOffersDTO = bookingOffersDTO;
    }
}