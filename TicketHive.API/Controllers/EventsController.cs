using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketHive.Application.DTOs;
using TicketHive.Application.Features.Events.Commands.CreateEvent;
using TicketHive.Application.Features.Events.Queries.GetEventsList;

namespace TicketHive.API.Controllers
{
    /// <summary>
    /// Entry point for Event-related API requests.
    /// Follows the 'Thin Controller' pattern by delegating all business logic to MediatR.
    /// </summary>
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

        // POST: api/events
        // Receives a command to create an event and returns the unique identifier of the created resource.
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            // The controller sends the command into the MediatR pipeline without knowing how it's handled.
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }
    }
}
