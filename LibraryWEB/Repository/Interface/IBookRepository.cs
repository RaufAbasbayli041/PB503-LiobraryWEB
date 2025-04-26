using LibraryWEB.DTO;
using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IBookRepository
    {
        Task<Book> CreateAsync (Book book);
        void Update (Book book);
        void Update2 (Book book);
        Task <List<Book>> GetAllAsync ();
        Task <Book> GetByIdAsync (int id);
        
    }
}
