using System;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetById{
    public class GetByIdQuery{
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public int BookId {get;set;}

        public GetByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {

            var book = _dbContext.Books.Where(book => book.ID == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap mevcut değil");

            BookViewModel bvm = _mapper.Map<BookViewModel>(book);
            
            /*BookViewModel bvm =  new BookViewModel(){
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreID).ToString(),
                PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                PageCount = book.PageCount
            };*/

            return bvm;
        }

        public class BookViewModel
        {
            public string Title{ get; set;}
            public int PageCount{ get; set;}
            public String PublishDate { get; set;}
            public string Genre{ get; set;}
        }


    }
}
