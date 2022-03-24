using FluentValidation;

namespace WebApi.Application.GenreOpretions.Commands.CreateGenre
{
    public class CreateGenreCommandValitador : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValitador()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);            
        }
    }
}