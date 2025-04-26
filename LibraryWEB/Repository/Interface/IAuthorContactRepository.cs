using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IAuthorContactRepository
    {
        Task<AuthorContact> CreatAsync(AuthorContact authorContact);
        void UpdateAsync(AuthorContact authorContact);
        Task<List<AuthorContact>> GetAllAsync();
        Task<AuthorContact> GetByIdAsync(int id);
    }
}
