using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.UpdateBook;

public class UpdateBookCommandValidator :  AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0);
        RuleFor(x => x.Model.GenreId).GreaterThan(0);
        RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(4);
    }
}
   