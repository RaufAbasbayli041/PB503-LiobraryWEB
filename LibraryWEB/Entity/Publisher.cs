namespace LibraryWEB.Entity
{
    public class Publisher : BaseEntity
    {       
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
