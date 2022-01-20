using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook{
    public class UpdateBookCommand{

        public UpdateBookModel Model{get;set;}
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id,UpdateBookModel updateBook)
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.ID == id);

            if(book is null)
                throw new InvalidOperationException("Kitap mevcut değil.");

            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
            book.GenreID = updateBook.GenreId != default ? updateBook.GenreId : book.GenreID;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;

            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title{get;set;}
            public int GenreId{get;set;}
            public int PageCount{get;set;}
            public DateTime PublishDate{get;set;}
        }

    }
}
        