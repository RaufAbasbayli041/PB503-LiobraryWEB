﻿using LibraryWEB.DTO;
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
            try
            {
           await _bookService.CreateAsync(bookDTO);

            return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(bookDTO);
            }

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
            try
            {
                await _bookService.Update(bookDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(bookDTO);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var items = await _bookService.GetByIdAsync(id);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           var data= await _bookService.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostDelete(int id)
        {
            try
            {

            await _bookService.DeleteAsync(id);
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
