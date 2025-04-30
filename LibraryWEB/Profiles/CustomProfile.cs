using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;

namespace LibraryWEB.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<AuthorDTO, Author>()
            .ForMember(dest => dest.Books, opt => opt.Ignore())
            .AfterMap((src, dest, context) =>
            {
                var allBooks = context.Items["AllBooks"] as List<Book>;
                if (allBooks != null)
                {
                    dest.Books = allBooks.Where(b => src.BookIds.Contains(b.Id)).ToList();
                }
            });
            CreateMap<Book,BookDTO>().ReverseMap();
            CreateMap<Author,AuthorDTO>().ReverseMap();
            CreateMap<AuthorContact,AuthorContactDTo>().ReverseMap();
            CreateMap<Publisher,PublisherDTO>().ReverseMap();
            CreateMap<BookCategory,BookCategoryDTO>().ReverseMap();
          
        }
    }
}
