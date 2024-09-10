using Domain.Entities;
using Infrastracture.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var _dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            var movies = _dbContext.Movies;
            var genres = _dbContext.Genres;
            var directors = _dbContext.Directors;
            var actors = _dbContext.Actors;
            var movieActor = _dbContext.MovieActors;
            var movieGenre = _dbContext.MovieGenres;

            if (!genres.Any())
{
                var genresData = new List<Genre>
                {
                    new Genre(Guid.NewGuid(), "Action"),
                    new Genre(Guid.NewGuid(), "Comedy"),
                    new Genre(Guid.NewGuid(), "Drama"),
                    new Genre(Guid.NewGuid(), "Thriller"),
                    new Genre(Guid.NewGuid(), "Sci-Fi")
                };

                _dbContext.Genres.AddRange(genresData);
                _dbContext.SaveChanges();
            }

            if (!directors.Any())
            {
                var directorsData = new List<Director>
                {
                    new Director(Guid.NewGuid(), "Steven", "Spielberg"),
                    new Director(Guid.NewGuid(), "Christopher", "Nolan"),
                    new Director(Guid.NewGuid(), "Martin", "Scorsese"),
                    new Director(Guid.NewGuid(), "Quentin", "Tarantino"),
                    new Director(Guid.NewGuid(), "Ridley", "Scott")
                };

                _dbContext.Directors.AddRange(directorsData);
                _dbContext.SaveChanges();
            }

            if (!actors.Any())
            {
                var actorsData = new List<Actor>
                {
                    new Actor(Guid.NewGuid(), "Leonardo", "DiCaprio"),
                    new Actor(Guid.NewGuid(), "Robert", "De Niro"),
                    new Actor(Guid.NewGuid(), "Brad", "Pitt"),
                    new Actor(Guid.NewGuid(), "Tom", "Hanks"),
                    new Actor(Guid.NewGuid(), "Morgan", "Freeman")
                };

                _dbContext.Actors.AddRange(actorsData);
                _dbContext.SaveChanges();
            }

            if (!movies.Any() && directors.Count() >= 5)
            {
                var directorsData = directors.ToList();

                var moviesData = new List<Movie>
                {
                    new Movie(Guid.NewGuid(), "Inception", new DateOnly(2010, 7, 16), directorsData[1]),
                    new Movie(Guid.NewGuid(), "Shutter Island", new DateOnly(2010, 2, 19), directorsData[2]),
                    new Movie(Guid.NewGuid(), "Pulp Fiction", new DateOnly(1994, 10, 14), directorsData[3]),
                    new Movie(Guid.NewGuid(), "Gladiator", new DateOnly(2000, 5, 5), directorsData[4]),
                    new Movie(Guid.NewGuid(), "Catch Me If You Can", new DateOnly(2002, 12, 25), directorsData[0])
                };

                _dbContext.Movies.AddRange(moviesData);
                _dbContext.SaveChanges();
            }

            if (!movieActor.Any() && movies.Count() >= 5 && actors.Count() >= 5)
            {
                var moviesData = movies.ToList();
                var actorsData = actors.ToList();

                var movieActorsData = new List<MovieActor>
                {
                    new MovieActor( moviesData[0].Id, actorsData[0].Id),
                    new MovieActor( moviesData[1].Id, actorsData[0].Id),
                    new MovieActor( moviesData[3].Id, actorsData[3].Id),
                    new MovieActor( moviesData[4].Id, actorsData[1].Id)
                };

                _dbContext.MovieActors.AddRange(movieActorsData);
                _dbContext.SaveChanges();
            }

            if (!movieGenre.Any() && movies.Count() >= 5 && genres.Count() >= 5)
            {
                var moviesData = movies.ToList();
                var genresData = genres.ToList();

                var movieGenresData = new List<MovieGenre>
                {
                    new MovieGenre(moviesData[0].Id, genresData[4].Id),
                    new MovieGenre(moviesData[1].Id, genresData[2].Id),
                    new MovieGenre(moviesData[2].Id, genresData[3].Id),
                    new MovieGenre(moviesData[3].Id, genresData[0].Id),
                    new MovieGenre(moviesData[4].Id, genresData[1].Id)
                };

                _dbContext.MovieGenres.AddRange(movieGenresData);
                _dbContext.SaveChanges();
            }


        }
    }
}