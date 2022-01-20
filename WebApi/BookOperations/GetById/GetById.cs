using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetById{
    public class GetByIdQuery{
        private readonly BookStoreDbContext _dbContext;

        public int BookId {get;set;}

        public GetByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookViewModel Handle()
        {

            var book = _dbContext.Books.Where(book => book.ID == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap mevcut değil");
            
            BookViewModel bvm=new BookViewModel(){
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreID).ToString(),
                PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                PageCount = book.PageCount
            };

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
