using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Model.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Model.LastName).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Model.DateOfBirth).NotEmpty();
    }
}