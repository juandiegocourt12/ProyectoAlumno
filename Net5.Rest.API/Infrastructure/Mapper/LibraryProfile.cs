using AutoMapper;
using Net5.Rest.Infrastructure.CrossCutting.Dtos;
using Net5.Rest.Infrastructure.CrossCutting.Helpers;
using Net5.Rest.Infrastructure.Data.Entities;

namespace Net5.Rest.API.Infrastructure.Mapper
{
    public class LibraryProfile:Profile
    {
        public LibraryProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)));

            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<AuthorForUpdateDto, Author>();
            CreateMap<BookForCreationDto,Book>();
        }
    }
}
