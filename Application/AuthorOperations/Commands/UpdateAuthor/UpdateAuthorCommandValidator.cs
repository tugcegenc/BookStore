using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.Model.FirstName).NotEmpty().MaximumLength(30).WithMessage("İsim boş olamaz.");
        RuleFor(command => command.Model.LastName).NotEmpty().MaximumLength(30).WithMessage("Soyisim boş olamaz.");
        
    }
}

