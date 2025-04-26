namespace LibraryWEB.Entity
{
    public class BookCategory : BaseEntity
    {
        public string Name { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
