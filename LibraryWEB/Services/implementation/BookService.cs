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
            var data = await _bookRepository.GetByIdAsync(id);
            var dto = _mapper.Map<BookDTO>(data);
            return dto;
        }

        public async void Update(BookDTO bookDTO)
        {
            var item = await _bookRepository.GetByIdAsync(bookDTO.Id);
            if (item is not null)
            {
             var entity = _mapper.Map<Book>(item);
                _bookRepository.Update2(entity);

            }
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _bookRepository.GetByIdAsync(id);
            if (data is not null)
            {
                data.IsDelated = 1;
                _bookRepository.Update(data);

            }
        }
    }
}
