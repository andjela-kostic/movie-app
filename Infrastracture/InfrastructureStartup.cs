using Domain.SharedKernel.Interfaces.Repository;
using Infrastracture.Persistance;
using Infrastracture.Persistance.Repositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure
{
    public class InfrastructureStartup
    {
        public IConfiguration Configuration { get; }

        public InfrastructureStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 29)));
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                AppDbInitializer.Seed(app);

            }
            
        }
    }
}