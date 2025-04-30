using AutoMapper;
using LibraryWEB.DataBase;
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
        private readonly LibraryDbContext _libraryDbContext;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository, LibraryDbContext libraryDbContext)
        {
            this._mapper = mapper;
            this._authorRepository = authorRepository;
            _libraryDbContext = libraryDbContext;
        }

        public async Task<AuthorDTO> CreateAsync(AuthorDTO authorDTO)
        {
            //var input = new Author
            //{
                
            //    Name = authorDTO.Name,
            //   CreatedDate = authorDTO.CreatedDate,
            //   Surname = authorDTO.Surname, 
            //   ContactId = authorDTO.ContactId,
            //   UpdateDate = authorDTO.UpdateDate,


            //};


            var input = _mapper.Map<Author>(authorDTO);
            var output = await _authorRepository.CreateAsync(input);
           
            
            foreach (var id in authorDTO.BookIds)
            {
                var bookauthor = new BookAuthors
                {
                    AuthorID = output.Id,
                    BookID = id,
                };
                await _libraryDbContext.BookAuthors.AddAsync(bookauthor);
                await _libraryDbContext.SaveChangesAsync();
            }
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
