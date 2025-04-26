namespace LibraryWEB.DTO
{
    public record AuthorContactDTo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
