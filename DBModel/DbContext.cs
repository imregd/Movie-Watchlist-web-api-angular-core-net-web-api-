using System.Text.Json.Serialization;

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel
{


    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public ICollection<UserMovies> UserMovies { get; set; } = null!;
    }
    public class UserMovies
    {
        public int id { get; set; }
        public string MovieName { get; set; } = "";
        public bool MovieWatched { get; set; }
        public int? MovieRating { get; set; }


        public int UserId { get; set; } // Foreign key to the User class

        [JsonIgnore] // Prevent the infinite cycle error aka "Self-referencing loop detected"
        public User User { get; set; } = null!; // Navigation property to the User class

        // the reason for this is so you can add multiple movies to a user
        // it would allow movies to be easily added along the lines of User.UserMovies.Add(moviestuff)
    }

    public class UserDTO // DTO to make POST easier for the user
    {
        public int UserId { get; set; }
        public List<UserMovies> UserMovies { get; set; } = null!;
    }

}

