using MediatR;
using TicketHive.Infrastructure.Data;

namespace TicketHive.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteEventCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _context.Events.FindAsync(new object[] { request.Id }, cancellationToken);

            if (eventToDelete == null)
                throw new KeyNotFoundException($"Event {request.Id} not found.");

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
