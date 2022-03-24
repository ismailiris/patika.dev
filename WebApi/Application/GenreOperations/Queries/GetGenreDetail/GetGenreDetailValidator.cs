using FluentValidation;

namespace WebApi.Application.GenreOpretions.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValitador : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValitador()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}