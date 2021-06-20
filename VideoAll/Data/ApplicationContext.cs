using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoAll.Models;

namespace VideoAll.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name = "Action" },
                new Genre() { GenreId = 2, Name = "Comedy" },
                new Genre() { GenreId = 3, Name = "Action-Comedy" },
                new Genre() { GenreId = 4, Name = "Romance" });

            modelBuilder.Entity<Actor>().HasData(
               new Actor() { ActorId = 1, FirstName = "Kenan", LastName = "Kurda", DayOfBirth = new DateTime(1961, 05, 29) },
               new Actor() { ActorId = 2, FirstName = "Bill", LastName = "Gates", DayOfBirth = new DateTime(1951, 07, 15) },
               new Actor() { ActorId = 3, FirstName = "Anthony", LastName = "Hopkins", DayOfBirth = new DateTime(1946, 03, 19) });

            modelBuilder.Entity<Video>().HasData(
                new Video() { VideoId = 1, Name = "Bad Boys", ImagePath = "some path" },
                new Video() { VideoId = 2, Name = "Indiana Jones", ImagePath = "some path" },
                new Video() { VideoId = 3, Name = "Alaska", ImagePath = "some path" });   
        }


        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
