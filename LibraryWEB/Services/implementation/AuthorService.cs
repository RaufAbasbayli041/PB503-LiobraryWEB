using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Implementation;
using LibraryWEB.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var datas = input.Books.Select(n=>new Author
            {

            }) ;
            var output = await _authorRepository.CreateAsync(input);
            var dto = _mapper.Map<AuthorDTO>(output);
            return dto;

        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("author not found", nameof(id));
            }
            var item = await _authorRepository.GetByIdAsync(id);
            if (item is not null)
            {
                item.IsDelated = 1;
               await _authorRepository.Update(item);
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
            if (id < 0)
            {
                throw new ArgumentException("author not found", nameof(id));
            }
            var data = await _authorRepository.GetByIdAsync(id);
            var dto = _mapper.Map<AuthorDTO>(data);
            return dto;
        }

        public async Task<SelectList> GetSelectListItems()
        {
            return await _authorRepository.GetSelectListItems();
        }

        public async Task UpdateAsync(AuthorDTO authorDTO)
        {
            if (authorDTO.Id < 1)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
            
            var data = await _authorRepository.GetByIdAsync(authorDTO.Id);
            if (data is not null)
            {
                var entity = _mapper.Map<Author>(authorDTO);
               await _authorRepository.Update(entity);  
            }
        }
    }
}
