using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketHive.Application.DTOs;
using TicketHive.Infrastructure.Data;

namespace TicketHive.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventDto>>
    {
        // Dependency injection of the database context
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; // 1. Inject IMapper

        // Constructor to initialize the handler with the database context
        public GetEventsListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Handle method to process the query and return a list of EventDto
        public async Task<List<EventDto>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            // 2. Fetch the raw Entities from database (PostgreSQL)
            var eventEntities = await _context.Events
                .OrderBy(x => x.Date)
                .ToListAsync(cancellationToken);

            // 3. Use AutoMapper to convert the list of Entities to a list of DTOs
            return _mapper.Map<List<EventDto>>(eventEntities);
        }
    }
}
