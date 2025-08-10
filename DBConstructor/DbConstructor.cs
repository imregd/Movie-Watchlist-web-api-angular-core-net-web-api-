using Microsoft.EntityFrameworkCore;
using Movie_Watchlist_web_api__angular___core_net_web_api_.DBModel;

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.DB_Constructor
{
    public class DB_Constructor : DbContext
    {
        public DB_Constructor(DbContextOptions<DB_Constructor> options) : base(options)
        {
        }
        public DbSet<> UserMovies { get; set; }
    }
