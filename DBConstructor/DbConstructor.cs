using Microsoft.EntityFrameworkCore;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel; // this lets us use the UserMovies class and simplifies to dbset

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.DB_Constructor
{
    public class DB_Constructor : DbContext
    {
        public DB_Constructor(DbContextOptions<DB_Constructor> options) : base(options)
        {
        }
        public DbSet<UserMovies> UserMovies { get; set; }

    }
}
