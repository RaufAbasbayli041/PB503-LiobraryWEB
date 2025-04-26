using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IBookCategoryRepository
    {
        Task<BookCategory> CreateAsync(BookCategory bookCategory);
        void Update(BookCategory bookCategory);
        void Update2(BookCategory bookCategory);
        Task<List<BookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int id);
    }
}
