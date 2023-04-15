using FlexBooking.Logic.Aggregates.BookingOffer.Dto;
using MediatR;

namespace FlexBooking.Logic.Aggregates.BookingOffer.Commands;

public class AddBookingOfferCommand : IRequest<Unit>
{
    public BookingOfferDto BookingOffer { get; set; }
}