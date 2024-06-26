﻿using BootCampStudyBuddy_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BootCampStudyBuddy_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavController : ControllerBase
    {
        StudyBuddyDbContext dbContext = new StudyBuddyDbContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Favorite> result = dbContext.Favorites.ToList();
            return Ok(result);
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // delete by favorite id
        {
            Favorite f = dbContext.Favorites.Find(id);
            if (f == null) { return NotFound(); }
            dbContext.Favorites.Remove(f);
            dbContext.SaveChanges();
            return NoContent();

        }

        [HttpGet("{id}")]

        public IActionResult GetById(string id)
        {
            
           List <Favorite>  result = dbContext.Favorites.Where(u => u.UserId == id).Include(u => u.Quiz).ToList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddFavorite([FromBody] FavDTO dtoFavorite)
        {
            Favorite newFavorite = new Favorite()
            {
                UserId = dtoFavorite.userID,
                QuizId = dtoFavorite.quizID
            };
            dbContext.Favorites.Add(newFavorite);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = newFavorite.Id }, newFavorite);
        }


    }
}
