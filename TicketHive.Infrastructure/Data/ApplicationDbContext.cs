using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Domain.Entities;

namespace TicketHive.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Dependency Injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

        // Entities in database
        public DbSet<Event> Events { get; set; }
    }
}
