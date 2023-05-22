using MediatR;

namespace FlexBooking.Logic.Aggregates.OfferLocation;

public class AddOfferLocationCommand: IRequest<int>
{
    public OfferLocationDto OfferLocation { get; set; }
}