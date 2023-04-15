using System.Text.Json.Serialization;
using FlexBooking.Logic.Aggregates.Hotel.Models;
using MediatR;
using Newtonsoft.Json;

namespace FlexBooking.Logic.Handlers;

public class GetHotelOffersQuery : IRequest<List<HotelOfferViewModel>>
{
    public string City { get; set; }
}