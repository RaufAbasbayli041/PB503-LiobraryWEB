using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IBookCategoryRepository
    {
        Task<BookCategory> CreatAsync(BookCategory bookCategory);
        void UpdateAsync(BookCategory bookCategory);
        Task<List<BookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int id);
    }
}
