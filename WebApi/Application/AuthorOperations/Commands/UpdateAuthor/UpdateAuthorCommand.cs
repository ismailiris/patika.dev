using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateCommand
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorCommandModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar mevcut değil");

            author.Name = Model.authorName != default ? Model.authorName : author.Name;
            author.Surname = Model.authorSurname != default ? Model.authorSurname : author.Surname;
            author.Birthday = Model.authorBirthday != default ? Model.authorBirthday : author.Birthday;

            _context.SaveChanges();
        }


    }

    public class UpdateAuthorCommandModel
    {
        public string authorName { get; set; }
        public string authorSurname { get; set; }
        public DateTime authorBirthday { get; set; }
    }
}