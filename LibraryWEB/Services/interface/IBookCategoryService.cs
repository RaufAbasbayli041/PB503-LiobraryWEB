using LibraryWEB.DTO;

namespace LibraryWEB.Services
{
    public interface IBookCategoryService
    {
        Task<BookCategoryDTO> CreateAsync(BookCategoryDTO bookCategoryDTO);
        void Update(BookCategoryDTO bookCategoryDTO);
        Task<List<BookCategoryDTO>> GetAllAsync();
        Task<BookCategoryDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
