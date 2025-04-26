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

        public async void Update(AuthorContact authorContact)
        {
          
            _context.AuthorContacts.Update(authorContact);
            _context.SaveChanges(); 


        }
    }
}
