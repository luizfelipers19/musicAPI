using Microsoft.EntityFrameworkCore;
using music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Data
{
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {
             
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Eye of the tiger",
                    Language = "English",
                    Duration = "3:30"
                },
                new Song
                {
                    Id = 2,
                    Title = "Despacito",
                    Language = "Español",
                    Duration = "3:23"
                }
                );
        }
    }
}
