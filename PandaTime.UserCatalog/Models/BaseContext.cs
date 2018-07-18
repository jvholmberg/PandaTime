using System;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class UserContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Group.SetupModel(modelBuilder);
            User.SetupModel(modelBuilder);
            Language.SetupModel(modelBuilder);
            Membership.SetupModel(modelBuilder);
            Role.SetupModel(modelBuilder);
            Post.SetupModel(modelBuilder);
            Comment.SetupModel(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            // Seed Database
            //Language languageSeed = new Language
            //{
            //    Name = "English",
            //    Code = "en",

            //};

            //User userSeed = new User
            //{
            //    Email = "admin@forkyfork.com",
            //    Password = "admin",
            //    FirstName = "Johan",
            //    LastName = "Holmberg",
            //    Activated = true,
            //    Language = null
            //};


            //modelBuilder.Entity<User>().HasData(userSeed);
        }
    }
}
