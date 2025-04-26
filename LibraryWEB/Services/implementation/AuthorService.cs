using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Implementation;
using LibraryWEB.Repository.Interface;

namespace LibraryWEB.Services.implementation
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
        {
            this._mapper = mapper;
            this._authorRepository = authorRepository;
        }

        public async Task<AuthorDTO> CreateAsync(AuthorDTO authorDTO)
        {
            var input = _mapper.Map<Author>(authorDTO);
            var output = await _authorRepository.CreateAsync(input);
            var dto = _mapper.Map<AuthorDTO>(output);
            return dto;

        }

        public async Task DeleteAsync(int id)
        {
            var item = await _authorRepository.GetByIdAsync(id);
            if (item is not null)
            {
                item.IsDelated = 1;
                _authorRepository.Update(item);
            }
        }

        public async Task<List<AuthorDTO>> GetAllAsync()
        {
            var datas = await _authorRepository.GetAllAsync();
            var dtos = _mapper.Map<List<AuthorDTO>>(datas);
            return dtos;
        }

        public async Task<AuthorDTO> GetByIdAsync(int id)
        {
            var data = await _authorRepository.GetByIdAsync(id);
            var dto = _mapper.Map<AuthorDTO>(data);
            return dto;
        }

        public async void Update(AuthorDTO authorDTO)
        {
            var data = await _authorRepository.GetByIdAsync(authorDTO.Id);
            if (data is not null)
            {
                var entity = _mapper.Map<Author>(data);
                _authorRepository.Update2(entity);  
            }
        }
    }
}
