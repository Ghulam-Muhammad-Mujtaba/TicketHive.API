using AutoMapper;
using MediatR;
using TicketHive.Application.DTOs;
using TicketHive.Infrastructure.Data;

namespace TicketHive.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventDto> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _context.Events.FindAsync(new object[] { request.Id }, cancellationToken);

            if (@event == null)
            {
                throw new KeyNotFoundException($"Event with ID {request.Id} was not found.");
            }

            return _mapper.Map<EventDto>(@event);
        }
    }
}
