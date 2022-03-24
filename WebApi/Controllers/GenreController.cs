using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Application.GenreOpretions.Commands.CreateGenre;
using WebApi.Application.GenreOpretions.Commands.DeleteGenre;
using WebApi.Application.GenreOpretions.Commands.UpdateGenre;
using WebApi.Application.GenreOpretions.Queries;
using WebApi.Application.GenreOpretions.Queries.GetGenreDetail;
using WebApi.Application.GenreOpretions.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //Get Methodu
        [HttpGet]

        public IActionResult GetGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_mapper, _context);
            var result = query.Handle();
            return Ok(result);
        }

        //İd ile Get Methodu
        [HttpGet("{id}")]
        public IActionResult GetGenreByID(int id)
        {
            GenreDetailsViewModel result;

            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper, _context);
            query.GenreId = id;

            GetGenreDetailQueryValitador validator = new GetGenreDetailQueryValitador();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        //post
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;

            CreateGenreCommandValitador validator = new CreateGenreCommandValitador();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //put
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreDetailCommandValitador validator = new UpdateGenreDetailCommandValitador();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreDetailCommandValitador validator = new DeleteGenreDetailCommandValitador();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

    }
}