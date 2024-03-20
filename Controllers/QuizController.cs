using BootCampStudyBuddy_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
namespace BootCampStudyBuddy_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        StudyBuddyDbContext dbContext = new StudyBuddyDbContext();

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Quiz> result = dbContext.Quizzes.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id) 
        {
            Quiz result = dbContext.Quizzes.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]  Quiz q)
        {
            q.Id = 0;
            dbContext.Quizzes.Add(q);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = q.Id }, q);
        }

        [HttpDelete]

        public IActionResult Delete(int id) 
        {
            Quiz q = dbContext.Quizzes.Find(id);
            if( q == null) { return NotFound(); }
            dbContext.Quizzes.Remove(q);
            dbContext.SaveChanges();
            return NoContent();

        }
    }
}
