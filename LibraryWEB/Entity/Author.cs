namespace LibraryWEB.Entity
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public int ContactId { get; set; }
        public AuthorContact AuthorContact { get; set; }


        public ICollection<BookAuthors> BookAuthors { get; set; }
    }
}
