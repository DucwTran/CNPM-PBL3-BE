using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<FavouriteCourse> Favourites { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Bill>().ToTable("Bills");
            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<Lesson>().ToTable("Lessons");
            modelBuilder.Entity<FavouriteCourse>().ToTable("Favourites");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<Course>().ToTable("Courses");

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<AdminUser>("AdminUser")
                .HasValue<AdminContent>("AdminContent")
                .HasValue<Student>("Student");
        }
    }
}