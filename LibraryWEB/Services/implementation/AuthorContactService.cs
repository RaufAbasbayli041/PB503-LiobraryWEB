using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Implementation;
using LibraryWEB.Repository.Interface;

namespace LibraryWEB.Services.implementation
{
    public class AuthorContactService : IAuthorContactService
    {
        private readonly IAuthorContactRepository _authorContactRepository;

        private readonly IMapper _mapper;
        public AuthorContactService(IAuthorContactRepository authorContactRepository, IMapper mapper)
        {
            _authorContactRepository = authorContactRepository;
            _mapper = mapper;
        }

        public async Task<AuthorContactDTo> CreateAsync(AuthorContactDTo athorContactDTo)
        {
            var inputData = _mapper.Map<AuthorContact>(athorContactDTo);
            var outputData = await _authorContactRepository.CreateAsync(inputData);
            var dto = _mapper.Map<AuthorContactDTo>(outputData);
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Contact not found", nameof(id));
            }
            var data =await _authorContactRepository.GetByIdAsync(id);
            if (data is not null)
            {
                data.IsDelated = 1;
                await _authorContactRepository.DeleteAsync(id);
            }
            
        }

        public async Task<List<AuthorContactDTo>> GetAllAsync()
        {
            var datas = await _authorContactRepository.GetAllAsync();
            var dto = _mapper.Map<List<AuthorContactDTo>>(datas);
            return dto;
        }

        public async Task<AuthorContactDTo> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("contact not found", nameof(id));
            }
            var data = await _authorContactRepository.GetByIdAsync(id);

            var dto = _mapper.Map<AuthorContactDTo>(data);
            return dto;
        }

        public async Task Update(AuthorContactDTo athorContactDTo)
        {
            var item = await _authorContactRepository.GetByIdAsync(athorContactDTo.Id);
            if (athorContactDTo.Id < 1)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
           

            if (item is not null)
            {
                var entity = _mapper.Map<AuthorContact>(athorContactDTo);
               await _authorContactRepository.UpdateAsync(entity);
            }
        }
    }
}
