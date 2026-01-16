using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Application.Features.Events.Commands.CreateEvent
{
    /// <summary>
    /// Data Transfer Object (DTO) representing the intent to create an event.
    /// Implements IRequest<Guid> to signal that this operation returns the ID of the new event.
    /// </summary>
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
