using FluentValidation;

namespace WebApi.Application.GenreOpretions.Commands.UpdateGenre
{
    public class UpdateGenreDetailCommandValitador : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreDetailCommandValitador()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }
}