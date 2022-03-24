using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailsQueryValitador : AbstractValidator<GetAuthorDetailsQuery>
    {
        public GetAuthorDetailsQueryValitador()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}