using Application.Common.ApiModels.MovieDTOs;
using Application.CQRS.Movies.Command;
using Application.CQRS.Movies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : BaseController
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/movie
    [HttpGet("/GetAllMovies")]
    [ProducesResponseType(200)]
    public async Task<ActionResult> GetMoviesAsync()
    {
        var result = await _mediator.Send(new GetMoviesQuery());
        return Ok(result);
    }
    
    // GET api/movie/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetMovieById(Guid id)
    {
        var result = await _mediator.Send(new GetMovieByIdQuery(id));

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    // POST api/movie
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> AddMovieAsync([FromBody] CreateMovieDTO createMovieDto)
    {
        if (createMovieDto == null)
        {
            return BadRequest("Invalid movie data.");
        }

        var movie = await _mediator.Send(new AddMovieCommand(createMovieDto));
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<MovieDTO>> UpdateMovieAsync(Guid id, [FromBody] UpdateMovieDTO updateMovieDto)
    {
        if (updateMovieDto == null)
        {
            return BadRequest("Invalid movie data.");
        }

        try
        {
            var movieDto = await _mediator.Send(new UpdateMovieCommand(id, updateMovieDto));
            return Ok(movieDto);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    // DELETE api/movie/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteMovieAsync(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteMovieCommand(id));
            return NoContent();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}