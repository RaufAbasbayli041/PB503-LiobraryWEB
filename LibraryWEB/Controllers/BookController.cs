using LibraryWEB.DTO;
using LibraryWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWEB.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _bookService.GetAllAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO bookDTO)
        {
           await _bookService.CreateAsync(bookDTO);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var item = await _bookService.GetByIdAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookDTO bookDTO)
        {
            await _bookService.Update(bookDTO); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var items = await _bookService.GetByIdAsync(id);
            return View(items);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return View();
        }
    }
}
