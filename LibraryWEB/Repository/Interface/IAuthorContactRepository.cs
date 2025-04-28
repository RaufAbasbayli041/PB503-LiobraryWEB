using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IAuthorContactRepository
    {
        Task<AuthorContact> CreateAsync(AuthorContact authorContact);
        void Update(AuthorContact authorContact);
        Task DeleteAsync(int id);
        Task<List<AuthorContact>> GetAllAsync();
        Task<AuthorContact> GetByIdAsync(int id);
    }
}
