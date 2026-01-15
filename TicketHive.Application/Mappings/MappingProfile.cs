using AutoMapper;
using TicketHive.Application.DTOs;
using TicketHive.Domain.Entities;

namespace TicketHive.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // This tells AutoMapper: "You can convert an Event entity into an EventDto"
            CreateMap<Event, EventDto>();

            // Conversion from end point request to Event entity
            // CreateMap<EventDto, Event>().ReverseMap();
        }
    }
}
