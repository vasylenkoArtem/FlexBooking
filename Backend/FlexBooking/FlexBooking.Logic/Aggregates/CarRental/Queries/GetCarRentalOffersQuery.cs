using FlexBooking.Logic.Aggregates.CarRental.Models;
using MediatR;

namespace FlexBooking.Logic.Aggregates.CarRental.Queries;

public class GetCarRentalOffersQuery: IRequest<List<CarRentalOfferViewModel>>
{
    public string City { get; set; }
}