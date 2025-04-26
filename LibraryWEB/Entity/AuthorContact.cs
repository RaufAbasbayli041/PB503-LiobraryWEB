namespace LibraryWEB.Entity
{
    public class AuthorContact : BaseEntity
    {
                public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
