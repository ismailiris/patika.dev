using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public int BookId { get; set; }

        public GetByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {

            var book = _dbContext.Books.Include(x=>x.Author).Include(x => x.Genre).Where(book => book.ID == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap mevcut değil");

            BookViewModel bvm = _mapper.Map<BookViewModel>(book);

            return bvm;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public String PublishDate { get; set; }
            public string Genre { get; set; }
            public string AuthorName { get; set; }
        }


    }
}
