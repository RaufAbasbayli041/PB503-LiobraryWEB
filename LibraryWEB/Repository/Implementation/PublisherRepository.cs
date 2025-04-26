using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LibraryWEB.Repository.Implementation
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryDbContext? _context;

        public PublisherRepository(LibraryDbContext? context)
        {
            _context = context;
        }

        public async Task<Publisher> CreatAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return publisher;   
        }

        public async Task<List<Publisher>> GetAllAsync()
        { 
            var datas = await _context.Publishers.ToListAsync();
            return datas;              
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            var data = await _context.Publishers.FindAsync(id);
            return data;
        }

        public void UpdateAsync(Publisher publisher)
        {
            _context.Update(publisher);
            _context.SaveChanges();
        }
    }
}
