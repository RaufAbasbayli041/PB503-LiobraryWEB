using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryWEB.Repository.Implementation
{
    public class AuthorContactRepository : IAuthorContactRepository
    {
        private readonly LibraryDbContext? _context;

        public AuthorContactRepository(LibraryDbContext? context)
        {
            _context = context;
        }

        public async Task<AuthorContact> CreateAsync(AuthorContact authorContact)
        {
            await _context.AuthorContacts.AddAsync(authorContact);
            await _context.SaveChangesAsync();
            return authorContact;

        }

        public async Task DeleteAsync(int id)
        {
            var authorContact = await _context.AuthorContacts.FindAsync(id);
            
            if (authorContact != null)
            {
                _context.AuthorContacts.Remove(authorContact);
              
            }
            else
            {
                throw new Exception("AuthorContact not found");
            }
        }

        public async Task<List<AuthorContact>> GetAllAsync()
        {
            var datas = await _context.AuthorContacts.ToListAsync();
            return datas;
        }

        public async Task<AuthorContact> GetByIdAsync(int id)
        {
            var data = await _context.AuthorContacts.FindAsync(id);
            return data;
        }

        public async Task UpdateAsync(AuthorContact authorContact)
        {
            var existingAuthorContact = await _context.AuthorContacts.FindAsync(authorContact.Id);
            if (existingAuthorContact == null)
            {
                throw new Exception("AuthorContact not found");
            }
            _context.Entry(existingAuthorContact).State = EntityState.Detached;
            _context.Attach(authorContact);
            _context.Entry(authorContact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
