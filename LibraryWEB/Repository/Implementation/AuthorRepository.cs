using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Authors.FindAsync(id);
            if (data == null)
            {
                throw new Exception("Author not found");
            }
            _context.Authors.Remove(data);
        }

        public async Task<List<Author>> GetAllAsync()
        {
            var datas = await _context.Authors.Include(m=>m.Books).ToListAsync();
            return datas.Where(x => x.IsDelated == 0).ToList();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var data = await _context.Authors.FindAsync(id);
            return data;
        }

        public async Task<SelectList> GetSelectListItems()
        {
            var datas = await _context.Books.ToListAsync();

            return new SelectList(datas, "Id", "Name");
        }

        public async Task Update(Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(author.Id);
            if (existingAuthor == null)
            {
                throw new Exception("Author not found");
            }
            _context.Entry(existingAuthor).State = EntityState.Detached;
            _context.Attach(author);
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
