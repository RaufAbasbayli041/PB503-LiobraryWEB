using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryWEB.Repository.Implementation
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly LibraryDbContext _context;

        public BookCategoryRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<BookCategory> CreatAsync(BookCategory bookCategory)
        {
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
            return bookCategory;
        }

        public async Task<List<BookCategory>> GetAllAsync()
        {
            var datas = await _context.BookCategories.ToListAsync();
            return datas;
        }

        public async Task<BookCategory> GetByIdAsync(int id)
        {
            var data = await _context.BookCategories.FindAsync(id);
            return data;
        }

        public void UpdateAsync(BookCategory bookCategory)
        {
            _context.BookCategories.Update(bookCategory);
            _context.SaveChanges();
        }
    }
}
