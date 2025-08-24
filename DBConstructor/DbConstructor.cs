using Microsoft.EntityFrameworkCore;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel; // this lets us use the UserMovies class and simplifies to dbset

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.DBConstructor
{
    public class DB_Constructor : DbContext
    {
        public DB_Constructor(DbContextOptions<DB_Constructor> options) : base(options)
        {
        }
        public DbSet<User> UserData { get; set; } = null!; // table for user data

        public DbSet<UserMovies> UserMovies { get; set; } = null!; // table for user movies so that data can be generated and stored

    }
}
