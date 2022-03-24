using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOpretions.Queries
{
    public class GetGenreDetailQuery
    {

        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public GenreDetailsViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            GenreDetailsViewModel returnObject = _mapper.Map<GenreDetailsViewModel>(genre);

            return returnObject;

        }

    }

    public class GenreDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}