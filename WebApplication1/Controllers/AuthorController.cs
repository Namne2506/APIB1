using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.LibraryManagement;
using WebApplication1.Repos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly Authorrepos repos;

        public AuthorController(Authorrepos authorrepos)
        {
            repos = authorrepos;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = repos.GetAll();
            try
            {
                return Ok(authors);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Author author)
        {
            try
            {
                var data = repos.Create(author);
                return StatusCode(201, data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var author = repos.GetAuthorById(id);
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
        public IActionResult Put(Author author)
        {
            try
            {
                var data = repos.Update(author);
                return StatusCode(201, data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
