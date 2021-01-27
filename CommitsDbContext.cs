using RepositoryScanner.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryScanner
{
    public class CommitsDbContext : DbContext
    {
        public DbSet<CommitModel> Commits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=commits.db");
        }
    }
}