namespace LibraryWEB.DTO
{
    public record BookDTO :BaseDTO
    {
      
        public string Description { get; set; }
        public int Pages { get; set; }
    }
}
