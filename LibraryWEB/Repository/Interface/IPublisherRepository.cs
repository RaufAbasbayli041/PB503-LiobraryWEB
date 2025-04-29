using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IPublisherRepository
    {
        Task<Publisher> CreateAsync(Publisher publisher);
        Task UpdateAsync(Publisher publisher);
        Task DeleteAsync(int id);
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);
    }
}
