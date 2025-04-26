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
    }
}
