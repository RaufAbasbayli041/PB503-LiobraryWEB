using LibraryWEB.DTO;
using LibraryWEB.Entity;

namespace LibraryWEB.Services
{
    public interface IBookService
    {
        Task<BookDTO> CreateAsync(BookDTO bookDTO);
        void Update(BookDTO bookDTO);
        Task<List<BookDTO>> GetAllAsync();
        Task<BookDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
