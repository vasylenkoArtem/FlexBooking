using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexBooking.API.Controllers;

[ApiController]
[Route("/api/booking-offers")]
public class BookingOffers: ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetTripOffers([FromBody] BookingOffersDTO request, [FromServices] IMediator mediator)
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
}