using System.Data.Entity;
using Avior.Database.Models;

namespace Avior.Database.Data
{
    public class AviorDbContext : DbContext
    {
        public AviorDbContext() : base("AviorDbConnection")
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
    }
}