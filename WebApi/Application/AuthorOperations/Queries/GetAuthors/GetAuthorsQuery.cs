using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorsQuery
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id);
            List<AuthorsViewModel> returnObject = _mapper.Map<List<AuthorsViewModel>>(authors);

            return returnObject;
        }

    }
    
    public class AuthorsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}