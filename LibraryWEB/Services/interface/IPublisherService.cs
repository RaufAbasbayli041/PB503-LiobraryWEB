using LibraryWEB.DTO;

namespace LibraryWEB.Services
{
    interface IPublisherService
    {
        Task<PublisherDTO> CreateAsync(PublisherDTO publisherDTO);
        Task Update(PublisherDTO publisherDTO);
        Task DeleteAsync(int id);
        Task<List<PublisherDTO>> GetAllAsync();
        Task<PublisherDTO> GetByIdAsync(int id);
    }
}
