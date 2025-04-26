using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> CreatAsync(Author author);
        void UpdateAsync(Author author);
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
    }
}
