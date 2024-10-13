using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.LibraryManagement;
using WebApplication1.Repos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepos repos;

        public BookController(BookRepos repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = repos.GetAll();
            try
            {
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Book book)
        {
            try
            {
                var data = repos.Create(book);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var author = repos.GetBookById(id);
                if (author == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(author);
                if (!deleted)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Book book)
        {
            try
            {
                var data = repos.Update(book);
                return StatusCode(404, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
