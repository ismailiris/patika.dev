using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int authorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            if (author is null)
                throw new InvalidOperationException("Yazar Mevcut Değil!");

            if( _context.Books.Any(x=>x.AuthorID == authorId))
                throw new InvalidOperationException("Yazarın kitabı mevcut olduğu için silinemez.");
                
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}