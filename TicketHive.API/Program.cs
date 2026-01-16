using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketHive.Application.Behaviors;
using TicketHive.Application.Features.Events.Commands.CreateEvent;
using TicketHive.Application.Features.Events.Queries.GetEventsList;
using TicketHive.Application.Mappings;
using TicketHive.Infrastructure.Data;

namespace TicketHive.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // --- Database Configuration ---
            // Configures Entity Framework Core to connect to the PostgreSQL instance.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // --- MediatR Registration ---
            // Registers MediatR to scan the 'Application' assembly for all Command/Query handlers.
            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(GetEventsListQuery).Assembly);

                // Registers our custom Validation Behavior into the MediatR request pipeline.
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            // --- AutoMapper Registration ---
            // Scans for 'Profile' classes to automate object-to-object mapping.
            // This works in v14 without any license key
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // --- FluentValidation Registration ---
            // Scans for all 'AbstractValidator' classes in the Application project.
            builder.Services.AddValidatorsFromAssembly(typeof(CreateEventCommand).Assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
