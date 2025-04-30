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
        public async Task<BookCategory> CreateAsync(BookCategory bookCategory)
        {
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
            return bookCategory;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.BookCategories.FindAsync(id);
            if (data == null)
            {
                throw new Exception("Category not found");
            }
            _context.BookCategories.Remove(data);
        }

        public async Task<List<BookCategory>> GetAllAsync()
        {
            var datas = await _context.BookCategories.ToListAsync();
            return datas.Where(x=>x.IsDelated==0).ToList();
        }

        public async Task<BookCategory> GetByIdAsync(int id)
        {
            var data = await _context.BookCategories.FindAsync(id);
            return data;
        }

  
        public async void Update(BookCategory bookCategory)
        {
            var existingCategory = await _context.BookCategories.FindAsync(bookCategory.Id);
            if (existingCategory == null)
            {
                throw new Exception("Category not found");
            }
            _context.Entry(existingCategory).State = EntityState.Detached;
            _context.Attach(bookCategory);
            _context.Entry(bookCategory).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
