using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(commad => commad.BookId).GreaterThan(0);
        }
    }
}