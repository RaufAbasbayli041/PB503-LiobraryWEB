using LibraryWEB.DTO;
using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IBookRepository
    {
        Task<Book> CreateAsync(Book book);
        Task Update(Book book);
        Task DeleteAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);

    }
}
