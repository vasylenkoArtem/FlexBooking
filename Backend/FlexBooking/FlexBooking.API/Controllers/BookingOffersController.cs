using FlexBooking.Logic.Aggregates.BookingOffer.Commands;
using FlexBooking.Logic.Aggregates.BookingOffer.Dto;
using FlexBooking.Logic.Aggregates.OfferLocation;
using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexBooking.API.Controllers;

[ApiController]
[Route("/api/booking-offers")]
public class BookingOffers : ControllerBase
{
    [HttpPost("search")]
    public async Task<IActionResult> GetTripOffers([FromBody] GetBookingOffersRequestParameters request,
        [FromServices] IMediator mediator)
    {
        // {
        //     "originCity": "Toronto",
        //     "destinationCity": "Montreal",
        //     "departureDate": "2023-04-08T20:27:50.287Z",
        //     "arrivalDate": "2023-04-10T22:27:50.287Z",
        //     "passengersCount": 4
        // }

        try
        {
            var query = new GetTripOffersQuery(request);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddBookingOffer([FromBody] BookingOfferDto dto,
        [FromServices] IMediator mediator)
    {
        try
        {
            var query = new AddBookingOfferCommand() { BookingOffer = dto };
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{offerId:int}")]
    public async Task<IActionResult> GetTripOfferDetailed(int offerId,
        [FromServices] IMediator mediator)
    {
        try
        {
            var query = new GetTripOfferDetailedQuery(offerId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}