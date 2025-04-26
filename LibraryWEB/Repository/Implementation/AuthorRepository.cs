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

        public async Task<Author> CreatAsync(Author author)
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

        public void UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
