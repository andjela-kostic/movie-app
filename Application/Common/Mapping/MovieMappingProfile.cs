using Application.Common.ApiModels.ActorDTOs;
using Application.Common.ApiModels.DirectorDTOs;
using Application.Common.ApiModels.MovieDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping;

public class MovieMappingProfile: Profile
{
    public MovieMappingProfile()
    {
        CreateMap<CreateMovieDTO, Movie>()
            .ForMember(dest => dest.Director, opt => opt.Ignore());
        
        CreateMap<UpdateMovieDTO, Movie>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<Director, DirectorDTO>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

        CreateMap<Movie, MovieDTO>()
            .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director));
    }
}