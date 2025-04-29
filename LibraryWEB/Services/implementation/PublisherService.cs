using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Implementation;
using LibraryWEB.Repository.Interface;

namespace LibraryWEB.Services.implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        public async Task<PublisherDTO> CreateAsync(PublisherDTO publisherDTO)
        {
           
            var inputData = _mapper.Map<Publisher>(publisherDTO);
            var outputData = await _publisherRepository.CreateAsync(inputData);
            var dto = _mapper.Map<PublisherDTO>(outputData);
            return dto;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PublisherDTO>> GetAllAsync()
        {
            var datas = await _publisherRepository.GetAllAsync();
            var dto = _mapper.Map<List<PublisherDTO>>(datas);
            return dto;
        }

        public async Task<PublisherDTO> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Publsiher not found", nameof(id));
            }
            var data = await _publisherRepository.GetByIdAsync(id);

            var dto = _mapper.Map<PublisherDTO>(data);
            return dto;
        }

        public async Task Update(PublisherDTO publisherDTO)
        {
            var item = await _publisherRepository.GetByIdAsync(publisherDTO.Id);
            if (publisherDTO.Id < 1)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
           

            if (item is not null)
            {
                var entity = _mapper.Map<Publisher>(publisherDTO);
               await _publisherRepository.UpdateAsync(entity);
            }
        }
    }
}
