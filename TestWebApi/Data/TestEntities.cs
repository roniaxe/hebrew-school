using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestWebApi.Models;

namespace TestWebApi.Data
{
    public class TestEntities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>().HasData(
                new Blog {Id = 1, Name = "Books Blog"},
                new Blog {Id = 2, Name = "Code Blog"},
                new Blog {Id = 3, Name = "Angular Blog"});
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
