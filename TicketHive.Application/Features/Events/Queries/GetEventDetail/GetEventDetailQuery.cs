using MediatR;
using TicketHive.Application.DTOs;

namespace TicketHive.Application.Features.Events.Queries.GetEventDetail
{
    public record GetEventDetailQuery(Guid Id) : IRequest<EventDto>;
   
}
