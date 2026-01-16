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

        // Seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                Name = "PostgreSQL Rock Night",
                Artist = "The Queries",
                Price = 45.00m,
                Date = DateTime.UtcNow.AddMonths(1),
                Description = "A night of high-performance music.",
                Capacity = 500
            });
        }

    }
}
