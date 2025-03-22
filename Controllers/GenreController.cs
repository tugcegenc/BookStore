using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.DeleteGenre;
using WebApi.Application.GenreOperations.Querie.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.UpdateGenre;
using WebApi.DBOperations;

namespace WebApi.Controllers;


[Route("[controller]s")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    
    public GenreController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;  
    }
    
    [HttpGet] 
    public IActionResult GetGenres()
    { 
        GetGenreQuery query = new GetGenreQuery(_context,  _mapper);
        var result = query.Handle();
        return Ok(result);
    }
         
         
    [HttpGet("{id}")] 
    public IActionResult GetById(int id)
    {
            //GenreDetailViewModel result;
            
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = id;
            
        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        validator.ValidateAndThrow(query); 
            
        var result = query.Handle();
        return Ok(result);
    }
         
         
    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = newGenre;
            
        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);
            
        command.Handle();
        return Ok();
    }
        

    [HttpPut ("{id}")] 
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.Model = updateGenre;
        command.GenreId = id;
            
        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);
            
        command.Handle(); 
        return Ok();
    }


    [HttpDelete("{id}")] 
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId = id;
            
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);
            
        command.Handle();
        return Ok();
    }
}
