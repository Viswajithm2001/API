using Microsoft.EntityFrameworkCore;
using MoviesAPI.Enitites;

namespace MoviesAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
    }
}
