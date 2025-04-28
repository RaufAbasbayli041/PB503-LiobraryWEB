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

        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            _context.Books.Remove(book);

            //await _context.Books
            //    .Where(x => x.Id == id)
            //    .ExecuteDeleteAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var datas = await _context.Books.ToListAsync();
           
            return datas.Where(x => x.IsDelated == 0).ToList();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var data = await _context.Books.FindAsync(id);
            return data;
        }
           

        public async Task Update(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null)
            {
                throw new Exception("Book not found");
            }

            _context.Entry(existingBook).State = EntityState.Detached;

            _context.Attach(book);
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
