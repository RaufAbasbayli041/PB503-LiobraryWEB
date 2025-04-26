using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;

namespace LibraryWEB.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Book,BookDTO>().ReverseMap();
            CreateMap<Author,AuthorDTO>().ReverseMap();
            CreateMap<AuthorContact,AuthorContactDTo>().ReverseMap();
            CreateMap<Publisher,PublisherDTO>().ReverseMap();
            CreateMap<BookCategory,BookCategoryDTO>().ReverseMap();
          
        }
    }
}
