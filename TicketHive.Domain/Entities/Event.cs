using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Domain.Common;

namespace TicketHive.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;

        // To track the availability of tickets
        public int Capacity { get; set; }
    }
}
