using System;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Group.SetupModel(modelBuilder);
            User.SetupModel(modelBuilder);
            Language.ConfigureTable(modelBuilder);
            Membership.SetupModel(modelBuilder);
            Role.SetupModel(modelBuilder);
            Post.SetupModel(modelBuilder);
            Comment.SetupModel(modelBuilder);

            Group.CreateSeed(modelBuilder);
            User.CreateSeed(modelBuilder);
            Language.CreateSeed(modelBuilder);
            Membership.CreateSeed(modelBuilder);
            Role.CreateSeed(modelBuilder);
            Post.CreateSeed(modelBuilder);
            Comment.CreateSeed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
