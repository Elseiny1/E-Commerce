using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class DebendencyInjection
    {
        public static void AddInfrastructrueServices(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentityCore<ECommerceUsers>()
            .AddEntityFrameworkStores<ECommerceDbContext>();
        }
    }
}
