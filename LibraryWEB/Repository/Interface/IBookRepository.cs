using LibraryWEB.DTO;
using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IBookRepository
    {
        Task<Book> CreatAsync (Book book);
        void UpdateAsync (Book book);
        Task <List<Book>> GetAllAsync ();
        Task <Book> GetByIdAsync (int id);
    }
}
