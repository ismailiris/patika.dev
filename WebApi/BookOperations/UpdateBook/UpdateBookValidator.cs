using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {

            RuleFor(commad => commad.BookId).GreaterThan(0);
            RuleFor(commad =>commad.Model.GenreId).GreaterThan(0);
            RuleFor(commad => commad.Model.PageCount).GreaterThan(0);
            RuleFor(commad => commad.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(commad => commad.Model.Title).NotEmpty().MinimumLength(4);

        }
    }
}