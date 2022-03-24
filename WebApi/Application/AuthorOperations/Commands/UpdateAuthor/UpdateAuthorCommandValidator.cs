using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateCommand
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(commad => commad.Model.authorName).NotEmpty().MinimumLength(4);
            RuleFor(commad => commad.Model.authorSurname).NotEmpty().MinimumLength(4);
            RuleFor(commad => commad.Model.authorBirthday).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}