using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAsync(Author author);
        void Update(Author author);
      
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
    }
}
