using FlexBooking.Logic.Aggregates.Hotel.Models;
using FlexBooking.Logic.Handlers;

namespace FlexBooking.API.Controllers;

using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/hotel-offers")]
public class HotelOffersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetHotelOffers([FromBody] GetHotelOffersQuery query,
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