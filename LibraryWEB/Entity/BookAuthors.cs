namespace LibraryWEB.Entity
{
    public class BookAuthors : BaseEntity
    {
        public int AuthorID { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
        public int BookID { get; set; }
    }
}
