using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using boardgamestore_skinsinger.Data.Models;

namespace boardgamestore_skinsinger.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<boardgamestore_skinsinger.Data.Models.BoardGame>? BoardGame { get; set; }
    }
}