using LibraryWEB.Entity;

namespace LibraryWEB.Repository.Interface
{
    public interface IPublisherRepository
    {
        Task<Publisher> CreatAsync(Publisher publisher);
        void UpdateAsync(Publisher publisher);
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);
    }
}
