using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Stocks> Stocks { get; set; } // Ensure this is public
        public DbSet<Comments> Comments { get; set; } // Ensure this is public
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stocks>()
                .HasKey(s => s.Id); // Define primary key explicitly

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Stock)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.StockId);
        }
    }
}