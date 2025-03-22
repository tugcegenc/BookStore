using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
{
    public GetAuthorDetailQueryValidator()
    {
        RuleFor(query => query.AuthorId).GreaterThan(0).WithMessage("Yazar Id'si sıfırdan büyük olmalıdır.");
    }
}