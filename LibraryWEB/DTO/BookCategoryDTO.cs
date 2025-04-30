using LibraryWEB.Entity;

namespace LibraryWEB.DTO
{
    public record BookCategoryDTO : BaseDTO
    {
		public int BookId { get; set; }
		public Book Book { get; set; }
	}
}
