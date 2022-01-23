using AutoMapper;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetById.GetByIdQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt =>opt.MapFrom(src=>((GenreEnum)src.GenreID).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt =>opt.MapFrom(src=>((GenreEnum)src.GenreID).ToString()));
        }
    }
}