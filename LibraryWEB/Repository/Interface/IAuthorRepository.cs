using LibraryWEB.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryWEB.Repository.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAsync(Author author );
        Task<SelectList> GetSelectListItems();
        Task Update(Author author);
        Task DeleteAsync(int id);
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
    }
}
