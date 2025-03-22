using FluentValidation;

namespace WebApi.Application.BookOperations.Queries;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
{
    public GetBookDetailQueryValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0);
        
    }
}