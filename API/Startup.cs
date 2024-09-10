using System.Reflection;
using Microsoft.OpenApi.Models;

namespace API;

public class Startup
{
    public Startup(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "MovieApp", 
                Version = "v1",
                Description = "An API to perform needed operations for the MovieApp",
            });   
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieApp");
        });
        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}