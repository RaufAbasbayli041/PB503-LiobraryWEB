using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IPublisherRepository
    {
        Task<Publisher> CreateAsync(Publisher publisher);
        void Update(Publisher publisher);
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);
    }
}
