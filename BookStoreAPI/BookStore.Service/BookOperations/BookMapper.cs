using AutoMapper;
using BookStore.DataAccess.Entities;

namespace BookStore.Service.BookOperations
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDto>()
                .ForMember(d => d.BookId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.BookName, o => o.MapFrom(s => s.Name));
        }
    }
}
