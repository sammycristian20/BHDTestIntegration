using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UserRegister.Models;

namespace UserRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Phones)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
