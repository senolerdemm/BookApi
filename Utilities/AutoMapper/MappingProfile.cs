using AutoMapper;
using ClassLibrary1.DataTransferObjects;
using ClassLibrary1.Models;

namespace WebApplication1.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookDtoForUpdate, Book>();
        CreateMap<Book, BookDto>();
        CreateMap<BookDtoForInsertion, Book>();
        CreateMap<UserForRegistirationDto,User>();
    }
}