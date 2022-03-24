using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOpretions.Queries.GetGenres
{
    public class GetGenreQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreQuery(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> returnObject = _mapper.Map<List<GenresViewModel>>(genres);

            return returnObject;

        }

    }

    public class GenresViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}