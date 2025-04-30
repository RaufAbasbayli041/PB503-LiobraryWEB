using LibraryWEB.DTO;
using LibraryWEB.Services;
using LibraryWEB.Services.implementation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWEB.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly IBookCategoryService _bookCategoryService;
        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _bookCategoryService.GetAllAsync();
            return View(datas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCategoryDTO bookCategoryDTO)
        {
            try
            {
                await _bookCategoryService.CreateAsync(bookCategoryDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(bookCategoryDTO);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _bookCategoryService.GetByIdAsync(id);
            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var item = await _bookCategoryService.GetByIdAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookCategoryDTO bookCategoryDTO)
        {
            try
            {
                await _bookCategoryService.Update(bookCategoryDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(bookCategoryDTO);
            }

        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _bookCategoryService.GetByIdAsync(id);
			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> PostDelete(int id)
		{
			try
			{

				await _bookCategoryService.DeleteAsync(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return View();
			}
		}
	}
}
