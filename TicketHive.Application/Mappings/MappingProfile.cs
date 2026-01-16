using AutoMapper;
using TicketHive.Application.DTOs;
using TicketHive.Application.Features.Events.Commands.CreateEvent;
using TicketHive.Domain.Entities;

namespace TicketHive.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // This tells AutoMapper: "You can convert an Event entity into an EventDto"
            CreateMap<Event, EventDto>();

            // For Commands (Command -> Entity)
            CreateMap<CreateEventCommand, Event>();
        }
    }
}
