namespace LibraryWEB.DTO
{
    public record BaseDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BaseDTO()
        {
            CreatedDate = DateTime.Now;
            UpdateDate = DateTime.UtcNow.AddHours(4);
        }
    }
}
