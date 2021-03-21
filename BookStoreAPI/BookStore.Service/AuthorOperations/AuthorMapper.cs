using AutoMapper;
using BookStore.DataAccess.Entities;

namespace BookStore.Service.AuthorOperations
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(d => d.AuthorId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Name));

            CreateMap<AuthorDto, Author>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.AuthorName));
        }
    }
}
