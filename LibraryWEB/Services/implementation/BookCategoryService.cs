using AutoMapper;
using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Repository.Implementation;
using LibraryWEB.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryWEB.Services.implementation
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;

        private readonly IMapper _mapper;
        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, IMapper mapper)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _mapper = mapper;
        }

        public async Task<BookCategoryDTO> CreateAsync(BookCategoryDTO bookCategoryDTO)
        {
            
            var inputData = _mapper.Map<BookCategory>(bookCategoryDTO);
            var outputData = await _bookCategoryRepository.CreateAsync(inputData);
            var dto = _mapper.Map<BookCategoryDTO>(outputData);
            return dto;
        }

        public async Task<List<BookCategoryDTO>> GetAllAsync()
        {

            var datas = await _bookCategoryRepository.GetAllAsync();
            var dtos = _mapper.Map<List<BookCategoryDTO>>(datas);
            return dtos;
        }
        public async Task<SelectList> GetSelectListItems()
        {
            return await _bookCategoryRepository.GetSelectListItems();
        }




        public async Task<BookCategoryDTO> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Categorie not found", nameof(id));
            }

            var data = await _bookCategoryRepository.GetByIdAsync(id);
            var dto = _mapper.Map<BookCategoryDTO>(data);
            return dto;
        }

        public async Task Update(BookCategoryDTO bookCategoryDTO)
        {
            if (bookCategoryDTO.Id < 1)
            {
                throw new ArgumentException("Id must be greater than 0");
            }

            var item = await _bookCategoryRepository.GetByIdAsync(bookCategoryDTO.Id);
            if (item is not null)
            {
                var entity = _mapper.Map<BookCategory>(bookCategoryDTO);
                _bookCategoryRepository.Update(entity);

            }
        }

        public async Task DeleteAsync(int id)
        {
          
            var item = await _bookCategoryRepository.GetByIdAsync( id);
            if (item is not null)
            {
                item.IsDelated = 1;
                _bookCategoryRepository.Update(item);
            }
        }
    }
}
