using LibraryWEB.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryWEB.Services
{
    public interface IAuthorService
    {
        Task<AuthorDTO> CreateAsync(AuthorDTO authorDTO);
        Task UpdateAsync(AuthorDTO authorDTO);
        Task<List<AuthorDTO>> GetAllAsync();
        Task<AuthorDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<SelectList> GetSelectListItems();
    }
}
