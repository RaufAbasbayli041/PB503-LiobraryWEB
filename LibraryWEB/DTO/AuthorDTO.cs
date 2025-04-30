using LibraryWEB.Entity;

namespace LibraryWEB.DTO
{
    public record AuthorDTO : BaseDTO
    {
        public string Surname { get; set; }
        public int ContactId { get; set; }
        public AuthorContact AuthorContact { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
