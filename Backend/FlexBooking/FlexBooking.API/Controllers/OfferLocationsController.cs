using FlexBooking.Logic.Aggregates.OfferLocation;
using FlexBooking.Logic.Aggregates.OfferLocation.Queries;
using FlexBooking.Logic.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexBooking.API.Controllers;

[ApiController]
[Route("/api/offer-locations")]
public class OfferLocationsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLocations([FromServices] IMediator mediator)
    {
        try
        {
            var query = new GetOfferLocationsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddOfferLocation([FromBody] OfferLocationDto dto,
        [FromServices] IMediator mediator)
    {
        try
        {
            var command = new AddOfferLocationCommand()
                { OfferLocation = dto };
            var locationId = await mediator.Send(command);

            return Ok(locationId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}