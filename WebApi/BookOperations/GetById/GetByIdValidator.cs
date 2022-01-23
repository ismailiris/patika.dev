using FluentValidation;

namespace WebApi.BookOperations.GetById
{
    public class GetByIdValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(commad => commad.BookId).GreaterThan(0);
        }
    }
}