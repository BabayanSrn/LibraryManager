using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Data;
using LibraryManager.Storage.Entities;
using LibraryManager.DataModels;
using LibraryManager.Repository.Interfaces;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            if (books == null)
            {
                return NotFound();
            }
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookModel bookmodel)
        {
            if (id != bookmodel.Id)
            {
                return BadRequest();
            }
            try
            {
                await _bookRepository.Update(bookmodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookModel bookmodel)
        {
            var book = await _bookRepository.Create(bookmodel);

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {

            var book = await _bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookRepository.Delete(book);

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _bookRepository.BookExist(id) != null;
        }
    }
}