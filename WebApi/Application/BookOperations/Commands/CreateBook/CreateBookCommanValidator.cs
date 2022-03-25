using System;
using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(commad => commad.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(commad => commad.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(commad => commad.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(commad => commad.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(commad => commad.Model.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}