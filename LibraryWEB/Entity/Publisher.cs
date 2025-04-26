namespace LibraryWEB.Entity
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
