using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryWEB.Services.implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> CreateAsync(BookDTO bookDTO)
        {
            //if (bookDTO is null)
            //{
            //    throw new ArgumentNullException(nameof(bookDTO));
            //}
            //if (string.IsNullOrWhiteSpace(bookDTO.Name))
            //{
            //    throw new ArgumentException("Name cannot be null or empty", nameof(bookDTO.Name));
            //}
            //if (string.IsNullOrWhiteSpace(bookDTO.Description))
            //{
            //    throw new ArgumentException("Description cannot be null or empty", nameof(bookDTO.Description));
            //}
            if (bookDTO.Pages < 1)
            {
                throw new ArgumentException("Pages must be greater than 0", nameof(bookDTO.Pages));
            }

            var inputData = _mapper.Map<Book>(bookDTO);
            var outputData = await _bookRepository.CreateAsync(inputData);
            var dto = _mapper.Map<BookDTO>(outputData);
            return dto;
        }

        public async Task<List<BookDTO>> GetAllAsync()
        {
            var datas = await _bookRepository.GetAllAsync();
            var dto = _mapper.Map<List<BookDTO>>(datas);
            return dto;
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Book not found", nameof(id));
            }
            var data = await _bookRepository.GetByIdAsync(id);

            var dto = _mapper.Map<BookDTO>(data);
            return dto;
        }

        public async Task Update(BookDTO bookDTO)
        {
            var item = await _bookRepository.GetByIdAsync(bookDTO.Id);
            if (bookDTO.Id <1)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
            if (bookDTO.Pages < 1)
            {
                throw new ArgumentException("Pages must be greater than 0", nameof(bookDTO.Pages));
            }

            if (item is not null)
            {
             var entity = _mapper.Map<Book>(bookDTO);
               await _bookRepository.Update(entity);                
            }
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _bookRepository.GetByIdAsync(id);
            
            if (data is not null)
            {
                data.IsDelated = 1;
                await _bookRepository.Update(data);

            }
        }
    }
}
