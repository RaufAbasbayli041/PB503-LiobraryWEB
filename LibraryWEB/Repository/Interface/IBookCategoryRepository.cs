using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IBookCategoryRepository
    {
        Task<BookCategory> CreateAsync(BookCategory bookCategory);
        void Update(BookCategory bookCategory);
        Task DeleteAsync(int id);
        Task<List<BookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int id);
    }
}
