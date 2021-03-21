using AutoMapper;
using BookStore.DataAccess.Entities;
using System.Linq;

namespace BookStore.Service.BookOperations
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDto>()
                .ForMember(d => d.BookId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.BookName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Authors, o => o.MapFrom(s => s.BookAuthorLinks.Select(x => x.Author)));

            CreateMap<BookDto, Book>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.BookName));
        }
    }
}
