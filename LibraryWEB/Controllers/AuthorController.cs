using LibraryWEB.DTO;
using LibraryWEB.Entity;
using LibraryWEB.Services;
using LibraryWEB.Services.implementation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWEB.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _authorService.GetAllAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Books = await _authorService.GetSelectListItems();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDTO authorDTO)
        {
            ViewBag.Books = await _authorService.GetSelectListItems();
            try
            {
                await _authorService.CreateAsync(authorDTO);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(authorDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var item = await _authorService.GetByIdAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorDTO authorDTO)
        {
            try
            {
                await _authorService.UpdateAsync(authorDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(authorDTO);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var items = await _authorService.GetByIdAsync(id);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _authorService.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostDelete(int id)
        {
            try
            {
                await _authorService.DeleteAsync(id);
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
