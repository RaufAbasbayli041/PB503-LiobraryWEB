using LibraryWEB.DTO;

namespace LibraryWEB.Services
{
    public interface IAuthorService
    {
        Task<AuthorDTO> CreateAsync(AuthorDTO authorDTO);
        void Update(AuthorDTO authorDTO);
        Task<List<AuthorDTO>> GetAllAsync();
        Task<AuthorDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
