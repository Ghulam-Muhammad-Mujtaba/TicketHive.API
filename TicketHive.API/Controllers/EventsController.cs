using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketHive.Application.DTOs;
using TicketHive.Application.Features.Events.Queries.GetEventsList;

namespace TicketHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        // Dependency injection of the mediator
        private readonly IMediator _mediator;

        // Constructor to initialize the controller with the mediator
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Events - Action to get all events
        [HttpGet]
        
        public async Task<ActionResult<List<EventDto>>> GetAllEvents()
        {
            // Send the GetEventsListQuery to the mediator and return the result
            var result = await _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }
    }
}
