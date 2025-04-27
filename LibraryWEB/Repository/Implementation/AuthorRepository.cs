using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LibraryWEB.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Author> CreateAsync(Author author)
        {
           await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();  
            return author;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            var datas = await _context.Authors.ToListAsync();
            return datas;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var data = await _context.Authors.FindAsync(id);
            return data;
        }

   

        public async void Update(Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(author.Id);
            if (existingAuthor == null)
            {
                throw new Exception("Author not found");
            }
            _context.Entry(existingAuthor).State = EntityState.Detached;
            _context.Attach(author);
            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
