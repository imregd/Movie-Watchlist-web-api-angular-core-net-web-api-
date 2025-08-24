using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBConstructor;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.Controllers
{
    [Route("api/users/{userid}/UserMovies")]
    [ApiController]
    public class UserMoviesController : ControllerBase
    {
        private readonly DB_Constructor _context;

        public UserMoviesController(DB_Constructor context)
        {
            _context = context;
        }

        private readonly Expression<Func<UserMovies, UserMoviesDTO>> UserMoviesDTOMapper = usermovie => new UserMoviesDTO //mapper so i dont have to reuse the same code over and over
        {
            Id = usermovie.Id,
            MovieName = usermovie.MovieName,
            MovieWatched = usermovie.MovieWatched,
            MovieRating = usermovie.MovieRating
        };

        // GET: api/UserMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMoviesDTO>>> GetUserMovies(int userid)
        {

            var movies = await _context.UserMovies
                .Where(um => um.UserId == userid) // Filter movies by the provided UserID
                .Select(UserMoviesDTOMapper) // Use the mapper to project to UserMoviesDTO
                .ToListAsync();

            return movies;
        }

        /*
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

        commented out because in the future i may add a future search query feature, where a user can search for a specific movie in their watchlist, idk tho
        */

        // PUT: api/UserMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{userid}/{id}")]
        public async Task<IActionResult> PutUserMovies(int userid,int id, UserMoviesDTO userMoviesDTO)
        {
            var userMovies = await _context.UserMovies
                .FirstOrDefaultAsync(um => um.Id == id && um.UserId == userid);

            if (userMovies == null)
            {
                return NotFound();
            }

            var movieDto = new UserMoviesDTO
            {
                Id = userMovies.Id,
                MovieName = userMovies.MovieName,
                MovieWatched = userMovies.MovieWatched,
                MovieRating = userMovies.MovieRating
            };
            


            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/UserMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userid}")]
        public async Task<ActionResult<UserMoviesDTO>> PostUserMovies(int userid, UserMoviesDTO userMovies)
        {
            var user = await _context.UserData.FindAsync(userid);

            if (user == null)
            {
                return NotFound($"User with ID {userid} not found.");
            }

            var newUserMovie = new UserMovies
            {
                MovieName = userMovies.MovieName,
                MovieWatched = userMovies.MovieWatched,
                MovieRating = userMovies.MovieRating,
                UserId = userid // Associate the movie with the specified user
            };

            _context.UserMovies.Add(newUserMovie);
            await _context.SaveChangesAsync();


            userMovies.Id = newUserMovie.Id; // Set the ID of the DTO to the newly created entity's ID
            return CreatedAtAction("GetUserMovies", new { id = newUserMovie.Id }, userMovies);
        }

        // DELETE: api/UserMovies/5
        [HttpDelete("{userid}/{id}")]
        public async Task<IActionResult> DeleteUserMovies(int userid, int id)
        {
            var usermovie = await _context.UserMovies
                .FirstOrDefaultAsync(um => um.Id == id && um.UserId == userid);

            if (usermovie == null)
            {
                return NotFound();
            }

            _context.UserMovies.Remove(usermovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
