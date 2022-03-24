using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(commad => commad.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(commad => commad.Model.Surname).NotEmpty().MinimumLength(4);
            RuleFor(commad => commad.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}