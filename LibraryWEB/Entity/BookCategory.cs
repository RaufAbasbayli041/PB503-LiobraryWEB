namespace LibraryWEB.Entity
{
    public class BookCategory : BaseEntity
    {
       
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
