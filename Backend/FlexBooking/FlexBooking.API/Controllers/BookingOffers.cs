using Microsoft.AspNetCore.Mvc;

namespace FlexBooking.API.Controllers;

[ApiController]
[Route("/api/booking-offers")]
public class BookingOffers: ControllerBase
{
    [HttpGet]
    public IActionResult GetTripOffers()
    {
        return Ok(new {});
    }
}