using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<ActionResult<IEnumerable<UserDTORead>>> GetUserData()
        {
            var AllUsers = await _context.UserData
                .Where(i => i.UserId > 0)
                .Select(user => new UserDTORead
                {
                    Username = user.Username,
                    UserMovies = user.UserMovies.Select(m => new UserMoviesDTO
                    {
                        MovieName = m.MovieName,
                        MovieWatched = m.MovieWatched,
                        MovieRating = m.MovieRating
                    }).ToList()
                })
                .ToListAsync();

            return AllUsers;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDTORead>>> GetUser(int id)
        {
            var UserSpecific = await _context.UserData
                .Where(i => i.UserId == id)
                .Select(user => new UserDTORead
                {
                    Username = user.Username,
                    UserMovies = user.UserMovies.Select(m => new UserMoviesDTO
                    {
                        MovieName = m.MovieName,
                        MovieWatched = m.MovieWatched,
                        MovieRating = m.MovieRating
                    }).ToList()
                })
                .ToListAsync();


            if (UserSpecific == null)
            {
                return NotFound();
            }

            return UserSpecific;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTORead user) // USERNAME CHANGE
        {

            var userExists = await _context.UserData
                .Where(i => i.UserId == id)
                .Select(u => new UserDTORead
                {
                    Username = u.Username,
                })
                .FirstOrDefaultAsync();

            if (userExists == null!)
            {
                return BadRequest();
            }

            userExists.Username = user.Username; // allows username to be changed, for now this is in but in the future will be removed or changed to a different system
           
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO user)
        {
            var DTOConvert = new User
            {
                Username = user.Username,
            };


            _context.UserData.Add(DTOConvert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = DTOConvert.UserId }, new UserDTORead {Username = DTOConvert.Username, UserMovies = new List<UserMoviesDTO>() });
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
