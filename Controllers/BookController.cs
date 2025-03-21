using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CeateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    { 
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           

        }
       /*private static List<Book> BookList = new List<Book>
       {
          new Book { Id = 1, Title = "Lean Startuup", GenreId = 1, PageCount =200, PublishDate = new DateTime(2001, 1, 1) },
          new Book { Id = 2, Title = "Herland", GenreId = 2, PageCount = 250, PublishDate = new DateTime(2002, 1, 1) },
          new Book { Id = 3, Title ="Dune", GenreId = 3, PageCount = 540, PublishDate = new DateTime(2003, 1, 1) }
         };*/

        [HttpGet]
         public IActionResult GetBooks()
         {
            GetBooksQuery query = new GetBooksQuery(_context,  _mapper);
            var result = query.Handle();
            return Ok(result);
            
         }
         
         [HttpGet("{id}")]
         public IActionResult GetById(int id)
         {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(result);
         }
         
         [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
           
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
           try
           {
               UpdateBookCommand command = new UpdateBookCommand(_context);
               command.Model = updatedBook;
               command.BookId = id;
               UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
               validator.ValidateAndThrow(command);
               command.Handle();
           }
           catch (Exception ex)
           {
               return BadRequest(ex.Message);
           }
              return Ok();
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
    
}