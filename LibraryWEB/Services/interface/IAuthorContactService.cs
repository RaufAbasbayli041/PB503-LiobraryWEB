using LibraryWEB.DTO;

namespace LibraryWEB.Services
{
    interface IAuthorContactService
    {
        Task<AuthorContactDTo> CreateAsync(AuthorContactDTo athorContactDTo);
        void Update(AuthorContactDTo athorContactDTo);
        Task<List<AuthorContactDTo>> GetAllAsync();
        Task<AuthorContactDTo> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
