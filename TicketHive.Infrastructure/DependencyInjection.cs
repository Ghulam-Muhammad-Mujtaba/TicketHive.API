using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketHive.Infrastructure.Data;

namespace TicketHive.Infrastructure
{
    public static class DependencyInjection
    {
        // This class is responsible for registering infrastructure services
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Get the Connection String from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 2. Register the DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
