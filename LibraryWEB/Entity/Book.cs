using Azure.Core.Pipeline;

namespace LibraryWEB.Entity
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<Author> Authors { get; set; }


    }
}
