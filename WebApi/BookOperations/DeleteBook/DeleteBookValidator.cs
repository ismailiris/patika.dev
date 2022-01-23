using FluentValidation;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(commad => commad.BookId).GreaterThan(0);
        }
    }
}