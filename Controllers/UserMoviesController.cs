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
using Microsoft.AspNetCore.JsonPatch;


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


        // GET: api/UserMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMoviesDTO>> GetUserMovies(int userid, int id)
        {
            var userMovies = await _context.UserMovies
                .Where(um => um.UserId == userid && um.Id == id) 
                .Select(UserMoviesDTOMapper)
                .FirstOrDefaultAsync();

            if (userMovies == null)
            {
                return NotFound();
            }

            return userMovies;
        }

        // commented out because in the future i may add a future search query feature, where a user can search for a specific movie in their watchlist, idk tho

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUserMovies(int userid ,int id, [FromBody] JsonPatchDocument<UserMoviesDTO> UpdatedMovies)
        {
            var userMovies = await _context.UserMovies
                .FirstOrDefaultAsync(um => um.Id == id && um.UserId == userid);

            if (userMovies == null)
            {
                return NotFound();
            }

            // thought of compiling the usermoviesdtomapper but it was unnecessary and could make it slower performance wise
            var movieDto = new UserMoviesDTO
            {
                MovieName = userMovies.MovieName,
                MovieWatched = userMovies.MovieWatched,
                MovieRating = userMovies.MovieRating
            };

            UpdatedMovies.ApplyTo(movieDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userMovies.MovieName = movieDto.MovieName;
            userMovies.MovieWatched = movieDto.MovieWatched;
            userMovies.MovieRating = movieDto.MovieRating;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/UserMovies
        [HttpPost]
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


            var responsedto = new UserMoviesDTOResponse
            {
                Id = newUserMovie.Id,
                MovieName = newUserMovie.MovieName,
                MovieWatched = newUserMovie.MovieWatched,
                MovieRating = newUserMovie.MovieRating
            };

            return CreatedAtAction("GetUserMovies", new { id = responsedto.Id, userid }, responsedto);
        }

        // DELETE: api/UserMovies/5
        [HttpDelete("{id}")]
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
