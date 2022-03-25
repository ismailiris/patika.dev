using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{

    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.Author).Include(x => x.Genre).OrderBy(x => x.ID).ToList<Book>();

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            /*List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel(){
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreID).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });
            }*/

            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public String PublishDate { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
    }

}
