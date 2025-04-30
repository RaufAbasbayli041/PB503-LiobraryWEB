using LibraryWEB.Entity;

namespace LibraryWEB.DTO
{
    public record BookDTO :BaseDTO
    {
      
        public string Description { get; set; }
        public int Pages { get; set; }
		public ICollection<BookCategory> BookCategories { get; set; }
		public ICollection<Author> Authors { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
    }
}
