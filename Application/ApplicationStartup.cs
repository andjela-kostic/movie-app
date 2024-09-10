using System.Reflection;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Common.Services.Implementation;
using AutoMapper;
using Domain.SharedKernel.Interfaces.Repository;
using Infrastracture.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Application;

public class ApplicationStartup
{
    public IConfigurationRoot Configuration { get; set; }

    public ApplicationStartup(IConfigurationRoot configurationRoot)
    {
        Configuration = configurationRoot;
    }

    public void ConfigureService(IServiceCollection service)
    {
        service.AddAutoMapper(typeof(MovieMappingProfile));
        service.AddScoped<IMapper>(sp =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieMappingProfile>();
            });
            return config.CreateMapper();
        });

        service.AddTransient<IMovieService, MovieService>();
        service.AddTransient<IMovieRepository, MovieRepository>(); 
        
        service.AddMediatR(Assembly.GetExecutingAssembly());
    }
}