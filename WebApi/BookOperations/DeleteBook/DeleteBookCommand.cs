using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.ID == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap mevcut değil.");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }

}