using FluentValidation;

namespace WebApi.Application.GenreOpretions.Commands.DeleteGenre
{
    public class DeleteGenreDetailCommandValitador : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreDetailCommandValitador()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);            
        }
    }
}