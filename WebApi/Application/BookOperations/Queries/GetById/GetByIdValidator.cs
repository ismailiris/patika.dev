using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetById
{
    public class GetByIdValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(commad => commad.BookId).GreaterThan(0);
        }
    }
}