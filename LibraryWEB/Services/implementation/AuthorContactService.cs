using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
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
            var data =await _authorContactRepository.GetByIdAsync(id);
            if (data is not null)
            {
                data.IsDelated = 1;
                await _authorContactRepository.DeleteAsync(id);
            }
            
        }

        public Task<List<AuthorContactDTo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorContactDTo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AuthorContactDTo athorContactDTo)
        {
            throw new NotImplementedException();
        }
    }
}
