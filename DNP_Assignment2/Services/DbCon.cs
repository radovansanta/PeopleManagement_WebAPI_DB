using DNP_Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace DNP_Assignment2.Services
{
    public class DbCon : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DB.db");
        }
        
    }
}