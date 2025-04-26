using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryWEB.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreatAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            _context.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var datas = await _context.Books.ToListAsync();
            return datas;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var data = await _context.Books.FindAsync(id);
            return data;
        }

        public async void UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChangesAsync();
        }
    }
}
