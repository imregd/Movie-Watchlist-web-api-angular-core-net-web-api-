using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBConstructor;

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMoviesController : ControllerBase
    {
        private readonly DB_Constructor _context;

        public UserMoviesController(DB_Constructor context)
        {
            _context = context;
        }

        // GET: api/UserMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMovies>>> GetUserMovies()
        {
            return await _context.UserMovies.ToListAsync();
        }

        // GET: api/UserMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMovies>> GetUserMovies(int id)
        {
            var userMovies = await _context.UserMovies.FindAsync(id);

            if (userMovies == null)
            {
                return NotFound();
            }

            return userMovies;
        }

        // PUT: api/UserMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMovies(int id, UserMovies userMovies)
        {
            if (id != userMovies.id)
            {
                return BadRequest();
            }

            _context.Entry(userMovies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMoviesExists(id))
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

        // POST: api/UserMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserMovies>> PostUserMovies(UserMovies userMovies)
        {
            _context.UserMovies.Add(userMovies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMovies", new { id = userMovies.id }, userMovies);
        }

        // DELETE: api/UserMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMovies(int id)
        {
            var userMovies = await _context.UserMovies.FindAsync(id);
            if (userMovies == null)
            {
                return NotFound();
            }

            _context.UserMovies.Remove(userMovies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMoviesExists(int id)
        {
            return _context.UserMovies.Any(e => e.id == id);
        }
    }
}
