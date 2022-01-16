using Animals.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dog>().HasData(
                new Dog { Name = "Neo", Color = "red & amber", TailLengt = 22, Weight = 32 });

            modelBuilder.Entity<Dog>().HasData(
                new Dog { Name = "Jessy", Color = "black & white", TailLengt = 7, Weight = 14 });
        }
    }
}
