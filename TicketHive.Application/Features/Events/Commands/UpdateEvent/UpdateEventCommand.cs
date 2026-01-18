using MediatR;

namespace TicketHive.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<Unit> // Unit means "void" in MediatR
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
