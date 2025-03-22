using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using FluentValidation;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public AuthorsController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    public IActionResult GetAuthors()
    {
        var query = new GetAuthorsQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthorById(int id)
    {
        var query = new GetAuthorDetailQuery(_context, _mapper) { AuthorId = id };
        var validator = new GetAuthorDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
    {
        var command = new CreateAuthorCommand(_context, _mapper) { Model = newAuthor };
        var validator = new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorCommand.UpdateAuthorModel updatedAuthor)
    {
        var command = new UpdateAuthorCommand(_context)
        {
            AuthorId = id,
            Model = updatedAuthor
        };
        var validator = new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        var command = new DeleteAuthorCommand(_context) { AuthorId = id };
        command.Handle();
        return Ok();
    }
}
