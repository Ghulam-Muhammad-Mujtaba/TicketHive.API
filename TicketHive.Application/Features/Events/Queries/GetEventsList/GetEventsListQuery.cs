using MediatR;
using TicketHive.Application.DTOs;

namespace TicketHive.Application.Features.Events.Queries.GetEventsList
{
    // This defines the request: "Give me a list of EventDto"
    public class GetEventsListQuery : IRequest<List<EventDto>>
    {

    }
}
