using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.LibraryManagement;
using WebApplication1.Repos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingController : ControllerBase
    {
        private readonly BookBorrowingRepos repos;

        public BookBorrowingController(BookBorrowingRepos repos)
        {
            this.repos = repos;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookBorrowings = repos.GetAll();
            try
            {
                return Ok(bookBorrowings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(BookBorrowing bookBorrowing)
        {
            try
            {
                var data = repos.Create(bookBorrowing);
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
                var author = repos.GetBookBorrowingById(id);
                if (author == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(id);
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
        public IActionResult Put(BookBorrowing bookBorrowing)
        {
            try
            {
                var data = repos.Update(bookBorrowing);
                return StatusCode(404, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
