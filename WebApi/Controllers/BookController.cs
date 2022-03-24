using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.BookOperations.Queries.GetById;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Queries.GetById.GetByIdQuery;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        //GET
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            BookViewModel result;
            // try
            // {
            GetByIdQuery query = new GetByIdQuery(_context, _mapper);
            query.BookId = id;

            //validation
            GetByIdValidator validator = new GetByIdValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            return Ok(result);
        }

        //POST
        [HttpPost]

        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;

            //validation 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();

        }

        //PUT

        [HttpPut("id")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
            // try
            // {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updateBook;
            //validation
            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            // }
            // catch(Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            return Ok();
        }

        /*
        var book = _context.Books.SingleOrDefault(x=>x.ID == id);

            if(book is null)
                return BadRequest();
            
            book.GenreID = updateBook.GenreID != default ?  updateBook.GenreID : book.GenreID;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

            _context.SaveChanges();
            return Ok();
        */

        //DELETE

        [HttpDelete("id")]

        public IActionResult DeleteBook(int id)
        {
            //    try
            //    {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;

            //validation
            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            //    }
            //    catch (Exception ex)
            //    {
            //         return BadRequest(ex.Message);
            //    }
            return Ok();
        }

    }
}