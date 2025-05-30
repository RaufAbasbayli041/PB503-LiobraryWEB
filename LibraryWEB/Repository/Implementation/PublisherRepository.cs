﻿using LibraryWEB.DataBase;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LibraryWEB.Repository.Implementation
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryDbContext _context;

        public PublisherRepository(LibraryDbContext? context)
        {
            _context = context;
        }

        public async Task<Publisher> CreateAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return publisher;   
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Publishers.FindAsync(id);
            if (data == null)
            {
                throw new Exception("Publisher not found");
            }
            _context.Publishers.Remove(data);
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

     
        public async Task UpdateAsync(Publisher publisher)
        {
            var existingPublisher = await _context.Publishers.FindAsync(publisher.Id);
            if (existingPublisher != null)
            {
                existingPublisher.Name = publisher.Name;
                existingPublisher.BookId = publisher.BookId;
               await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Publisher not found");
            }
        }
    }
}
