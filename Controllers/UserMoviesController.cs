using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBConstructor;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel;

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.Controllers
{
    [Route("api/users/{Id}/movies")]
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
        public async Task<ActionResult<IEnumerable<UserMoviesDTO>>> GetUserMoviesDTO()
        {
            return await _context.UserMoviesDTO.ToListAsync();
        }

        // GET: api/UserMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMoviesDTO>> GetUserMoviesDTO(int id)
        {
            var userMoviesDTO = await _context.UserMoviesDTO.FindAsync(id);

            if (userMoviesDTO == null)
            {
                return NotFound();
            }

            return userMoviesDTO;
        }

        // PUT: api/UserMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMoviesDTO(int id, UserMoviesDTO userMoviesDTO)
        {
            if (id != userMoviesDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(userMoviesDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMoviesDTOExists(id))
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
        public async Task<ActionResult<UserMoviesDTO>> PostUserMoviesDTO(UserMoviesDTO userMoviesDTO)
        {
            _context.UserMoviesDTO.Add(userMoviesDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMoviesDTO", new { id = userMoviesDTO.Id }, userMoviesDTO);
        }

        // DELETE: api/UserMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMoviesDTO(int id)
        {
            var userMoviesDTO = await _context.UserMoviesDTO.FindAsync(id);
            if (userMoviesDTO == null)
            {
                return NotFound();
            }

            _context.UserMoviesDTO.Remove(userMoviesDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMoviesDTOExists(int id)
        {
            return _context.UserMoviesDTO.Any(e => e.Id == id);
        }
    }
}
