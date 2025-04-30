using LibraryWEB.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryWEB.Services
{
    public interface IBookCategoryService
    {
        Task<BookCategoryDTO> CreateAsync(BookCategoryDTO bookCategoryDTO);
        Task Update(BookCategoryDTO bookCategoryDTO);
        Task<List<BookCategoryDTO>> GetAllAsync();
        Task<BookCategoryDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<SelectList> GetSelectListItems();
    }
}
