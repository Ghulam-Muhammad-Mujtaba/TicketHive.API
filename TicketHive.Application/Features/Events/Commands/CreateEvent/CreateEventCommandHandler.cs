using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Domain.Entities;
using TicketHive.Infrastructure.Data;

namespace TicketHive.Application.Features.Events.Commands.CreateEvent
{
    /// <summary>
    /// Logic handler for the CreateEventCommand.
    /// This keeps the application logic decoupled from the API layer.
    /// </summary>
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Handle method to process the CreateEventCommand.
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // 1. Map Command to Entity
            // Use AutoMapper to transform the Command (DTO) into a Domain Entity.
            // This prevents manual mapping and reduces boilerplate code.
            var @event = _mapper.Map<Event>(request);

            // 2. Add to DbContext (PostgreSQL tracking)
            _context.Events.Add(@event);

            // 3. Save to database (PostgreSQL)
            // Cancellation token ensures the task stops if the user cancels the request.
            await _context.SaveChangesAsync(cancellationToken);

            // 4. Return the generated Guid to the caller.
            return @event.Id;
        }
    }
}
