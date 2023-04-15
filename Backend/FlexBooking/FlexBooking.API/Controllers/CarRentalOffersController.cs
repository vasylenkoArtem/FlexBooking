using FlexBooking.Logic.Aggregates.CarRental.Queries;

namespace FlexBooking.API.Controllers;

using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/car-rentals")]
public class CarRentalOffersController: ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetCarRentalOffers([FromBody] GetCarRentalOffersQuery query,
        [FromServices] IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}