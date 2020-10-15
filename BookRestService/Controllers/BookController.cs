using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRestService.Model;
using Microsoft.AspNetCore.Mvc;
using BookLibraryAssignemnt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList;

        public BookController()
        {
            BookList = DB_Books.BookList;
        }


        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return BookList;
        }

        // GET api/<BookController>/5
        [HttpGet("{isbn13}")]
        public IActionResult Get(string isbn13)
        {
            var book = DB_Books.GetAllBooks(isbn13);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound(new { message = " Id not Found!" });
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {

            if (!BookExists(newBook.Isbn))
            {
                BookList.Add(newBook);
                return CreatedAtAction("Get", new { Isbn13 = newBook.Isbn }, newBook);
            }
            else
            {
                return NotFound(new { message = "Isbn13 is duplicate" });
            }

        }

        // PUT api/<BookController>/5
        [HttpPut("{Isbn13}")]
        public IActionResult Put(string Isbn13, [FromBody] Book updatedBook)
        {
            if (Isbn13 != updatedBook.Isbn)
            {
                return BadRequest();
            }

            Book currentBook = DB_Books.GetAllBooks(Isbn13);

            if (currentBook != null)
            {
                BookList.Remove(currentBook);
                BookList.Add(updatedBook);

            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{isbn13}")]
        public IActionResult Delete(string isbn13)
        {
            var book = DB_Books.GetAllBooks(isbn13);
            if (book != null)
            {
                BookList.Remove(book);
            }
            else
            {
                return NotFound();
            }

            return Ok(book);
        }


        // Helper method

        private bool BookExists(string isbn13)
        {
            return BookList.Any(b => b.Isbn == isbn13);
        }
    }
}
