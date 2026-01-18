using AutoMapper;
using MediatR;
using TicketHive.Infrastructure.Data;

namespace TicketHive.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _context.Events.FindAsync(new object[] { request.Id }, cancellationToken);

            if (eventToUpdate == null)
            {
                throw new KeyNotFoundException($"Event {request.Id} not found.");
            }

            // Map the command properties onto the existing entity
            _mapper.Map(request, eventToUpdate);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
