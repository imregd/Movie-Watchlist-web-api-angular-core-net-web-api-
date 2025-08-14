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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly DB_Constructor _context;


        public UsersController(DB_Constructor context)
        {
            _context = context;

        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserData()
        {
            var userdata = await (from b in _context.UserData
                                  select new UserDTO
                                  {
                                      UserId = b.UserId,
                                      UserMovies = b.UserMovies
                                                   .Select(m => new UserMoviesDTO
                                                   {
                                                       Id = m.Id,
                                                       MovieName = m.MovieName,
                                                       MovieWatched = m.MovieWatched,
                                                       MovieRating = m.MovieRating
                                                   }).ToList()
                                  }).ToListAsync();

            return userdata;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser(int id)
        {
            var userdata = await (from b in _context.UserData
                                  where b.UserId == id
                                  select new UserDTO
                                  {
                                      UserId = b.UserId,
                                      UserMovies = b.UserMovies
                                                   .Select(m => new UserMoviesDTO
                                                   {
                                                       Id = m.Id,
                                                       MovieName = m.MovieName,
                                                       MovieWatched = m.MovieWatched,
                                                       MovieRating = m.MovieRating
                                                   }).ToList()
                                  }).ToListAsync();


            if (userdata == null)
            {
                return NotFound();
            }

            return userdata;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.UserData.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.UserData.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserData.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.UserData.Any(e => e.UserId == id);
        }
    }
}
