using FluentValidation;
using WebApi.Application.BookOperations.Commands.CreateBook;

namespace WebApi.Application.BookOperations.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Model.GenreId).GreaterThan(0);
        RuleFor(x => x.Model.PageCount).GreaterThan(0);
        RuleFor(x => x.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(4);
    }
}

